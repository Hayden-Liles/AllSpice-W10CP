namespace W10CP.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (title, img, category, creatorId)
            VALUES
            ('title', 'notImage', 'Category', '641b5a46851b5157202b8287');
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.id = id;
            return recipeData;
        }

        internal List<Recipe> GetRecipes()
        {
            string sql = @"
            SELECT
            *
            FROM recipes;
            ";
            List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
            return recipes;
        }

        internal Recipe UpdateRecipe(Recipe recipeData)
        {
            string sql = @"
            UPDATE recipes SET
            title = @title,
            img = @img,
            category = @category
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, recipeData);
            return recipeData;
        }
    }
}