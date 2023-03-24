namespace W10CP.Repositories
{
    public class FavoritesRepositories
    {
        private readonly IDbConnection _db;

        internal int CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (accountId, recipeId)
            VALUES
            (@AccountId, @RecipeId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, favoriteData);
        }
    }
}