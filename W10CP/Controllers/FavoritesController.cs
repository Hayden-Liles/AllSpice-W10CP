namespace W10CP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService favoritesService;
        public FavoritesController(FavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        [HttpPost]
        public ActionResult<Favorite> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Favorite createdFavorite = favoritesService.CreateFavorite(favoriteData);
                return Ok(createdFavorite);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}