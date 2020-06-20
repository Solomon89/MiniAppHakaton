<template>
    <div class="base">
        <div class="cover-wrapper">
            <span class="h2">Здравствуйте, {{currentUserInfo.first_name}}</span>
        </div>
        <map-component></map-component>
    </div>
</template>

<script>
    import bridge from '@vkontakte/vk-bridge';
    import MapComponent from "@/js/components/MapComponent";

    export default {
        name: "BaseComponent",
        components: {MapComponent},
        data() {
            return {
                currentUserInfo: undefined
            }
        },
        async created() {
            await bridge.send('VKWebAppInit');
            this.currentUserInfo = await bridge.send('VKWebAppGetUserInfo')
        },
    }
</script>

<style scoped lang="scss">
.cover-wrapper{
    position: absolute;
    z-index: 1;
}
</style>