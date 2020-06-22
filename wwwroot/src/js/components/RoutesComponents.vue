<template>
    <div class="modal">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Маршруты</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"
                            @click="$emit('closed')">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table class="table table-striped">
                        <thead>
                        <tr>
                            <th></th>
                            <th>Название</th>
                            <th>Дистанция</th>
<!--                            <th>Дата</th>-->
                            <th>Максимальная скорость</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr v-for="track in tracks" :key="track.id">
                            <th scope="row"></th>
                            <td>{{track.name}}</td>
                            <td>{{track.distance}} м</td>
<!--                            <td>{{// track.start_date}}</td>-->
                            <td>{{track.max_speed}} км/ч</td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import $ from "jquery";

    export default {
        name: "RoutesComponents",
        props: {
            vkId: Number
        },
        data() {
            return {
                tracks: undefined
            }
        },
        async mounted() {
            this.tracks = await $.ajax({
                type: 'GET',
                url: `/Strava/GetLastTrack?VkId=${this.vkId}`,
            });
        }
    }
</script>

<style lang="scss" scoped>
    .modal {
        display: block;
    }

    tbody {
        font-size: 12px;
    }
</style>