<template>
    <div v-if="!has_errors" class="base">
        <div class="cover-wrapper">
            <nav-bar-component :vk-id="currentUserInfo.id"
                               :profile-name="currentUserInfo.hasOwnProperty('first_name')?currentUserInfo.first_name:''"
                               :profile-photo-url="currentUserInfo.photo_100"></nav-bar-component>

        </div>
        <map-component :npc-info="npc_info" :location="currentUserLocation" :vk-id="currentUserInfo.id"></map-component>
        <notification-component v-if="!is_strava_auth" title_text="Нужна авторизация" :body_text="getATag"
                                :vk-id="currentUserInfo.id" @closed="is_strava_auth=true"></notification-component>
    </div>
    <div v-else class="alert-danger">
        {{currentUserLocation.error_data.error_reason}}
    </div>
</template>

<script>
    import bridge from '@vkontakte/vk-bridge';
    import MapComponent from "@/js/components/MapComponent";
    import NavBarComponent from "@/js/components/NavBarComponent";
    import NotificationComponent from "@/js/components/NotificationComponent";
    import $ from "jquery";

    export default {
        name: "BaseComponent",
        components: {NotificationComponent, NavBarComponent, MapComponent},
        data() {
            return {
                currentUserInfo: {},
                currentUserLocation: {},
                npc_info: undefined,
                has_errors: false,
                is_strava_auth: false
            }
        },
        async created() {
            this.npc_info = (await this.init())
            console.log(this.npc_info)
        },
        methods: {
            async init() {
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

                return $.ajax({
                    type: 'GET',
                    url: `/Api/MapController/MapInit?vkId=${this.currentUserInfo.id}&&lat=${this.currentUserLocation.lat}&&lon=${this.currentUserLocation.long}`,
                });
            }
        },
        computed: {
            authUrl() {
                return `/Strava/AuthInStrava?VkId=${this.currentUserInfo.id}`
            },
            getATag() {
                return `<a href="${this.authUrl}" class="btn btn-primary">Войти в STRAVA</a>`
            }


        }
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