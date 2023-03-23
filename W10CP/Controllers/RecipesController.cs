namespace W10CP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
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

        [HttpPut]
        [Authorize]

        async public Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe recipeData){
            try 
            {
                Account accountInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Recipe recipe = _recipesService.UpdateRecipe(recipeData, accountInfo);
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
    }
}