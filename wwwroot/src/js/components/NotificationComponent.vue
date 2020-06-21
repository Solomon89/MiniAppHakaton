<template>
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
                <div class="modal-body" v-html="body_text">
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
        }
    }
</script>

<style lang="scss" scoped>
    .modal {
        display: block;
    }
</style>