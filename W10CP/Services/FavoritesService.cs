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
            favoriteData.id = id;
            return favoriteData;
        }
    }
}