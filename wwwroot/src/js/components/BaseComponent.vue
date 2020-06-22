<template>
    <div v-if="!has_errors" class="base">
        <div class="cover-wrapper">
            <nav-bar-component :vk-id="currentUserInfo.id" @show-router="show_routes=true"
                               :profile-name="currentUserInfo.hasOwnProperty('first_name')?currentUserInfo.first_name:''"
                               :profile-photo-url="currentUserInfo.photo_100"></nav-bar-component>

        </div>
        <map-component :npc-info="npc_info" :location="currentUserLocation" :vk-id="currentUserInfo.id"></map-component>
        <notification-component v-if="!is_strava_auth" title_text="Нужна авторизация" :body_text="getATag"
                                :vk-id="currentUserInfo.id" @closed="is_strava_auth=true"></notification-component>
        <routes-components v-if="show_routes" @closed="show_routes=false" :vk-id="currentUserInfo.id"></routes-components>
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
    import RoutesComponents from "@/js/components/RoutesComponents";

    export default {
        name: "BaseComponent",
        components: {RoutesComponents, NotificationComponent, NavBarComponent, MapComponent},
        data() {
            return {
                currentUserInfo: {},
                currentUserLocation: {},
                npc_info: undefined,
                has_errors: false,
                is_strava_auth: false,
                show_routes:false
            }
        },
        async created() {
            let tmp = (await this.init())
            this.npc_info = {
                "buildings": [{
                    "id": 31,
                    "eventId": 0,
                    "user": {"color": "ff00ff"},
                    "radius": 5,
                    "lat": 55.72997,
                    "lon": 37.747379,
                    "name": "Башня славы великих дотнетчиков",
                    "icon": "fortress.png",
                    "type": "building"
                }, {
                    "id": 32,
                    "eventId": 0,
                    "user": null,
                    "radius": 10,
                    "lat": 55.73456,
                    "lon": 37.747541,
                    "name": "Башня славы великих джавистов",
                    "icon": "fortress.png",
                    "type": "building"
                }],
                "mobs": [{
                    "id": 43,
                    "eventId": 0,
                    "lat": 55.729326,
                    "lon": 37.754682,
                    "name": "Безсонная ночь",
                    "icon": "mobIcon.png",
                    "reward": 150000,
                    "type": "mob"
                }],
                "events": [{
                    "id": 13,
                    "eventId": 0,
                    "reward": 1000,
                    "lat": 55.73019,
                    "lon": 37.739582,
                    "name": "Супер модный забег от Nike, во имя запуска ConquerRun",
                    "icon": "fortress.png",
                    "type": "event"
                }]
            }

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
                // return `/Strava/AuthInStrava?VkId=${this.currentUserInfo.id}`
                return `https://www.strava.com/oauth/authorize?client_id=49974&response_type=code&redirect_uri=https://user209080935-7rf6f3mj.wormhole.vk-apps.com//strava/exchange_token/${this.currentUserInfo.id}&approval_prompt=force&scope=read,activity:read`
            },
            getATag() {
                return `<a target="_blank" href="${this.authUrl}" class="btn btn-primary">Войти в STRAVA</a>`
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