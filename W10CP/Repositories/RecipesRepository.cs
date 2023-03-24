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
            (title, instructions, img, category, creatorId)
            VALUES
            (@title, @instructions, @img, @category, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.id = id;
            return recipeData;
        }

        internal void DeleteRecipe(int recipeId)
        {
            string sql = @"
            DELETE
            FROM recipes
            WHERE recipes.id = @recipeId;
            ";
            int check = _db.Execute(sql, new { recipeId });
            if(check == 0){
                throw new Exception("no recipe with such ID");
            }
        }

        internal Recipe GetOneRecipe(int id)
        {
            string sql = @"
            SELECT
            recipes.*,
            accounts.*
            from recipes
            JOIN accounts ON recipes.creatorId = accounts.id
            WHERE recipes.id = @id
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, acc) => {
                recipe.creator = acc;
                return recipe;
            }, new{ id }).FirstOrDefault();
            if(recipe == null){
                throw new Exception("no recipe with such ID");
            }
            return recipe;
        }

        internal List<Recipe> GetRecipes()
        {
            string sql = @"
            SELECT
            recipes.*,
            accounts.*
            FROM recipes
            JOIN accounts ON recipes.creatorId = accounts.id;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, acc) => {
                recipe.creator = acc;
                return recipe;
            }).ToList();
            return recipes;
        }

        internal Recipe UpdateRecipe(Recipe recipeData)
        {
            string sql = @"
            UPDATE recipes SET
            title = @title,
            instructions = @instructions,
            img = @img,
            category = @category
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, recipeData);
            return recipeData;
        }
    }
}