﻿<template>
    <div class="modal">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">{{title_text}}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"
                            @click="$emit('closed')">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <a target="_blank" :href="authUrl" @click="$emit('closed')" class="btn btn-primary">Войти в STRAVA</a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "NotificationComponent",
        props: {
            title_text: String,
            body_text: String,
            vkId: Number
        },
        computed: {
            authUrl() {
                // return `/Strava/AuthInStrava?VkId=${this.currentUserInfo.id}`
                return `https://www.strava.com/oauth/authorize?client_id=49974&response_type=code&redirect_uri=https://user209080935-wkeocojg.wormhole.vk-apps.com/strava/exchange_token/${this.vkId}&approval_prompt=force&scope=read,activity:read`
            },
        }
    }
</script>

<style lang="scss" scoped>
    .modal {
        display: block;
    }
</style>