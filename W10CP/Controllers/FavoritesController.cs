namespace W10CP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth = null)
        {
            _favoritesService = favoritesService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.accountId = userInfo.Id;
                return Ok(_favoritesService.CreateFavorite(favoriteData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{favoriteId}")]
        [Authorize]
        async public Task<ActionResult<string>> DeleteFavorite(int favoriteId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
                return Ok("Successfully deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}