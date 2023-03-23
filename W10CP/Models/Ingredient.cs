namespace W10CP.Models
{
    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }
        public Recipe recipeId { get; set; }
    }
}