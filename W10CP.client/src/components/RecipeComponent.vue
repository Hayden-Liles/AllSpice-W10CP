<template>
        <div class="card" style="background-image: url('{{recipe.img}}');">
            <div class="card-body d-flex justify-content-between flex-column">
                <div class="d-flex justify-content-between">
                    <div class="category bg-blur px-2 py-1 text-white fw-semibold">
                        <p>{{recipe.category}}a</p>
                    </div>
                    <div class="category bg-blur px-2 py-1 text-white fw-semibold">
                        <i class="mdi mdi-heart-outline"></i>
                    </div>
                </div>
                <div class="bg-blur px-2 py-1 text-white">
                    <p class="fs-5 fw-semibold">{{recipe.title}}</p>
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


<style lang="scss" scoped></style>