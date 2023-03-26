<template>
<div class="container-fluid">
  <div class="row">
    <div class="col-11 m-auto header-img mt-4" style="background-image: url('https://tinyurl.com/2jlml726')">
      <Login/>
    </div>
  </div>
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
import Login from '../components/Login.vue';
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
    components: { RecipeComponent, Login }
}
</script>

<style scoped lang="scss">
p{
  margin: 0;
}
.header-img{
  height: 350px;
  background-position: middle;
  background-size: cover;
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.25);
  filter: brightness(0.9);
}
</style>
