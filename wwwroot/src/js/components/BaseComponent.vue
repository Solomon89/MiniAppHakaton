<template>
    <div v-if="!has_errors" class="base">
        <div class="cover-wrapper">
            <nav-bar-component :profile-name="currentUserInfo.hasOwnProperty('first_name')?currentUserInfo.first_name:''" :profile-photo-url="currentUserInfo.photo_100"></nav-bar-component>
        </div>
        <map-component :location="currentUserLocation"></map-component>
    </div>
    <div v-else class="alert-danger">
        {{currentUserLocation.error_data.error_reason}}
    </div>
</template>

<script>
    import bridge from '@vkontakte/vk-bridge';
    import MapComponent from "@/js/components/MapComponent";
    import NavBarComponent from "@/js/components/NavBarComponent";

    export default {
        name: "BaseComponent",
        components: {NavBarComponent, MapComponent},
        data() {
            return {
                currentUserInfo: {},
                currentUserLocation: {},
                has_errors: false
            }
        },
        async created() {
            await bridge.send('VKWebAppInit');
            this.currentUserInfo = await bridge.send('VKWebAppGetUserInfo')
            let temp = await bridge.send('VKWebAppGetUserInfo')
            if (!temp.hasOwnProperty('first_name')) {
                this.has_errors = true
            }
            this.currentUserInfo = temp
            temp = await bridge.send('VKWebAppGetGeodata')
            if (temp.type === 'VKWebAppGeodataFailed') {
                this.has_errors = true
            }
            this.currentUserLocation = temp

        },
    }
</script>

<style scoped lang="scss">
    .cover-wrapper {
        /*pointer-events: none;*/
        position: absolute;
        z-index: 1;
        /**{*/
        /*    pointer-events: none;*/
        /*}*/
    }
</style>