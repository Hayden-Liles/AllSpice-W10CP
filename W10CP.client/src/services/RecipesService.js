import { AppState } from '../AppState'
import { api } from './AxiosService';
import { logger } from '../utils/Logger'

class RecipesService{

    async getAllRecipes(){
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
        logger.log(AppState.recipes)
    }
}

export const recipesService = new RecipesService()