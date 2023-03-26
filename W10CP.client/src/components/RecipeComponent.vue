<template>
    <div class="card m-auto" :style="{ 'background-image': 'url(' + recipe.img + ')' }">
        <div class="card-body d-flex justify-content-between flex-column">
            <div class="d-flex justify-content-between">
                <div class="category bg-blur px-2 py-1 text-white fw-semibold">
                    <p>{{ recipe.category }}a</p>
                </div>
                <div class="category bg-blur text-white fw-semibold d-flex">
                    <button class="py-1 px-2">
                        <i class="mdi mdi-heart-outline"></i>
                    </button>
                </div>
            </div>
            <div class="bg-blur px-2 py-1 text-white">
                <p class="fs-5 fw-semibold">{{ recipe.title }}</p>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    props: {
        recipe: {
            type: Object,
            required: true
        }
    },
    setup() {
        return {

        }
    }
}
</script>


<style lang="scss" scoped>
p {
    margin: 0;
}
button{
    background: none;
    border: none;
    outline: none;
    padding: 0;
    margin: 0;
}

.card {
    width: 350px;
    height: 350px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.25);
    background-size: cover;
    border-width: 0;
}

.bg-blur {
    background: rgba(126, 126, 126, 0.6);
    border: 0.5px solid #BBBBBB;
    backdrop-filter: blur(25px);
    border-radius: 5px;
}

.category {
    width: fit-content;
}</style>