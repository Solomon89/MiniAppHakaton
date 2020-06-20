<template>
    <map-component></map-component>
</template>

<script>
    import bridge from '@vkontakte/vk-bridge';
    import MapComponent from "@/js/components/MapComponent";
    export default {
        name: "BaseComponent",
        components: {MapComponent},
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