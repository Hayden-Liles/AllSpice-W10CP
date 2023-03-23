namespace W10CP.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe GetOneRecipe(int id)
        {
            Recipe recipe = _repo.GetOneRecipe(id);
            return recipe;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _repo.GetRecipes();
            if(recipes == null){
                throw new Exception("no recipe with such ID");
            }
            return recipes;
        }

        internal Recipe UpdateRecipe(Recipe recipeData, string Id)
        {
            Recipe checkRec = _repo.GetOneRecipe(recipeData.id);
            if(checkRec.creatorId != Id){
                throw new UnauthorizedAccessException("You are unable to edit this Recipe");
            }
            checkRec.title = recipeData.title != null ? recipeData.title : checkRec.title;
            checkRec.instructions = recipeData.instructions != null ? recipeData.instructions : checkRec.instructions;
            checkRec.img = recipeData.img != null ? recipeData.img : checkRec.img;
            checkRec.category = recipeData.category != null ? recipeData.category : checkRec.category;
            Recipe recipe = _repo.UpdateRecipe(checkRec);
            return recipe;
        }
    }
}