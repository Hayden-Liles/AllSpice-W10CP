<template>
<div class="container">
  <div class="row mt-5" v-if="recipes">
    <div class="col-4 my-3" v-for="recipe in recipes">
      <RecipeComponent :recipe="recipe"/>
    </div>
  </div>
</div>
</template>

<script>
import { onMounted, computed } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';
import RecipeComponent from '../components/RecipeComponent.vue';
import { logger } from '../utils/Logger';
export default {
    setup() {
        onMounted(() => {
            recipesService.getAllRecipes();
            logger.log('mounted');
        });
        return {
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { RecipeComponent }
}
</script>

<style scoped lang="scss">
p{
  margin: 0;
}
</style>
