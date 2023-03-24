namespace W10CP.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int CreateIngredient(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, ingredientData);
        }

        internal void DeleteIngredient(int ingredientId)
        {
            string sql = @"
            DELETE FROM ingredients
            WHERE id = @ingredientId;";
            _db.Execute(sql, new { ingredientId });
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT
            ingredients.*,
            recipes.*
            FROM ingredients
            JOIN recipes ON recipes.id = ingredients.recipeId
            WHERE recipes.id = @recipeId;";
            return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
            {
                ingredient.recipe = recipe;
                return ingredient;
            }, new { recipeId }, splitOn: "id").ToList();
        }
    }
}