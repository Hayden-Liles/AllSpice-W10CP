namespace W10CP.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _repo.GetRecipes();
            return recipes;
        }

        internal Recipe UpdateRecipe(Recipe recipeData, Account accountInfo)
        {
            if(recipeData.creatorId != accountInfo.Id){
                throw new UnauthorizedAccessException("You are unable to edit this Recipe");
            }
            Recipe recipe = _repo.UpdateRecipe(recipeData);
            return recipe;
        }
    }
}