namespace W10CP.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            int id = _repo.CreateIngredient(ingredientData);
            ingredientData.id = id;
            return ingredientData;
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
            return ingredients;
        }

        internal void DeleteIngredient(int ingredientId)
        {
            _repo.DeleteIngredient(ingredientId);
        }
    }
}