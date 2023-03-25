namespace W10CP.Repositories
{
    public class FavoritesRepositories
    {
        private readonly IDbConnection _db;
        public FavoritesRepositories(IDbConnection db)
        {
            _db = db;
        }

        internal int CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (accountId, recipeId)
            VALUES
            (@accountId, @recipeId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, favoriteData);
        }

        internal void DeleteFavorite(int favoriteId)
        {
            string sql = @"
            DELETE
            FROM favorites
            WHERE id = @favoriteId;";
            _db.Execute(sql, new { favoriteId });
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            string sql = @"
            SELECT
            *
            FROM favorites
            WHERE id = @favoriteId;";
            return _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
        }

        internal List<FavoriteRecipe> GetFavorites(string id)
        {
            string sql = @"
            SELECT
            a.*,
            f.id as favoriteId
            FROM favorites f
            JOIN recipes a ON a.id = f.recipeId
            WHERE f.accountId = @id;";
            return _db.Query<FavoriteRecipe>(sql, new { id }).ToList();
        }
    }
}