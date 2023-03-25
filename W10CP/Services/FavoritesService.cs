namespace W10CP.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepositories _repo;

        public FavoritesService(FavoritesRepositories repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            int id = _repo.CreateFavorite(favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }

        internal void DeleteFavorite(int favoriteId, string userId)
        {
            Favorite favorite = _repo.GetFavoriteById(favoriteId);
            if (favorite == null)
            {
                throw new Exception("Invalid Id");
            }
            if (favorite.accountId != userId)
            {
                throw new Exception("Invalid User");
            }
            _repo.DeleteFavorite(favoriteId);
        }

        internal List<FavoriteRecipe> GetFavorites(string id)
        {
            List<FavoriteRecipe> favorites = _repo.GetFavorites(id);
            return favorites;
        }
    }
}