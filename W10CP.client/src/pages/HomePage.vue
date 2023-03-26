<template>
<div class="container">
  <div class="row m-auto mt-5" v-if="recipes">
    <div class="col-4" v-for="recipe in recipes">
      <RecipeComponent :recipe="recipe"/>
    </div>
  </div>
</div>
</template>

<script>
import { onMounted } from 'vue';
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
            recipes: onMounted(() => AppState.recipes)
        };
    },
    components: { RecipeComponent }
}
</script>

<style scoped lang="scss">
p{
  margin: 0;
}
.card{
  width: 350px;
  height: 350px;
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.25);
  background-size: cover;
  border-width: 0;
}
.bg-blur{
  background: rgba(126, 126, 126, 0.6);
  border: 0.5px solid #BBBBBB;
  backdrop-filter: blur(10px);
  border-radius: 5px;
}
.category{
  width: fit-content;
}
</style>
