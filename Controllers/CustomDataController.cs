using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Easyweb.Models;
using System.Linq;
using System;

namespace Easyweb.Controllers
{
    [Route("drinks")]
    public class DrinksController : Controller
    {
        private readonly string listUrl = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=coffee";
        private readonly string detailUrl = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=";

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(listUrl);

            var allDrinks = JsonSerializer
                .Deserialize<CoffeeCocktailList>(json)?
                .drinks
                ?.Where(d => !BlockedDrinks.Contains(d.strDrink))
                .ToList() ?? new List<DrinkSummary>();

            return View(allDrinks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            using var httpClient = new HttpClient();

            // Get the selected drink
            var jsonDetail = await httpClient.GetStringAsync(detailUrl + id);
            var detail = JsonSerializer.Deserialize<CoffeeCocktailDetailResponse>(jsonDetail)?
                .drinks?.FirstOrDefault();

            // Get all drinks for the list below
            var jsonList = await httpClient.GetStringAsync(listUrl);
            var allDrinks = JsonSerializer.Deserialize<CoffeeCocktailList>(jsonList)?
            .drinks?
            .Where(d => 
                !BlockedDrinks.Contains(d.strDrink) &&
                d.idDrink != id // ← remove the one you selected at the momement
            )
            .ToList() ?? new List<DrinkSummary>();
            // combine both in a vievModel
            var viewModel = new DrinkDetailsViewModel
            {
                SelectedDrink = detail,
                AllDrinks = allDrinks
            };

            return View(viewModel);
        }

        // Unappropriate names banned
        private static readonly List<string> BlockedDrinks = new()
        {
            "Fuzzy Asshole", "Sex on the Beach", "Orgasm", "Buttery Nipple"
        };
    }
}
