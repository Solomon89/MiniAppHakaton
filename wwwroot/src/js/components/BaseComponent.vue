<template>
    
</template>

<script>
    import bridge from '@vkontakte/vk-bridge';
    export default {
        name: "BaseComponent",
        data(){
            return{
                
            }
        },
        mounted() {
            bridge.send('VKWebAppInit');  
        },
    }
</script>

<style scoped lang="scss">

</style>