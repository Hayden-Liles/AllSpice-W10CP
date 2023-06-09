namespace W10CP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, IngredientsService ingredientsService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _ingredientsService = ingredientsService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData){
            try 
            {
                Account accountInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipeData.creatorId = accountInfo.Id;
                Recipe recipe = _recipesService.CreateRecipe(recipeData);
                recipe.creator = accountInfo;
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{recipeId}")]
        [Authorize]
        async public Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe recipeData, int recipeId){
            try 
            {
                Account accountInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipeData.id = recipeId;
                Recipe recipe = _recipesService.UpdateRecipe(recipeData, accountInfo.Id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipes(){
            try 
            {
                List<Recipe> recipes = _recipesService.GetRecipes();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetOneRecipe(int recipeId){
            try 
            {
                Recipe recipe = _recipesService.GetOneRecipe(recipeId);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{recipeId}")]
        [Authorize]
        async public Task<ActionResult<Recipe>> DeleteRecipe(int recipeId){
            try 
            {
                Account accountInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                _recipesService.DeleteRecipe(recipeId, accountInfo.Id);
                return Ok("Successfully Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId){
            try 
            {
                List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}