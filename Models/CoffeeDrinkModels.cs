using System.Collections.Generic;

namespace Easyweb.Models
{
    public class CoffeeCocktailList
    {
        public List<DrinkSummary> drinks { get; set; }
    }

    public class DrinkDetailsViewModel
    {
        public CoffeeCocktailDetail SelectedDrink { get; set; }
        public List<DrinkSummary> AllDrinks { get; set; }
    }

    public class DrinkSummary
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
    }

    public class CoffeeCocktailDetailResponse
    {
        public List<CoffeeCocktailDetail> drinks { get; set; }
    }

    public class CoffeeCocktailDetail
    {
        public string strDrink { get; set; }
        public string strInstructions { get; set; }
        public string strDrinkThumb { get; set; }

        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }

        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
    }
}