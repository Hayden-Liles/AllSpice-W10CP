namespace W10CP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpPost]
        public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
        {
            try
            {
                Ingredient createdIngredient = _ingredientsService.CreateIngredient(ingredientData);
                return Ok(createdIngredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{ingredientId}")]
        public ActionResult<string> DeleteIngredient(int ingredientId)
        {
            try
            {
                _ingredientsService.DeleteIngredient(ingredientId);
                return Ok("Ingredient Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}