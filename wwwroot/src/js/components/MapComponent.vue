<template>
    <div class="d-flex justify-content-center align-items-center mt-5">
        <div id="map"></div>
    </div>
</template>

<script>
    import ymaps from 'ymaps';

    export default {
        name: "MapComponent",
        data() {
            return {
                myMap: undefined,
                colors: [
                    'ff00ff',
                    'ff0000',
                    '00ff00',
                    '0000ff',
                    '000000'
                ]
            }
        },
        methods: {
            drawPolygon(maps, coords) {
                let myPolygon = new maps.Polygon([
                    coords
                ], {
                    hintContent: "Многоугольник"
                }, {
                    fillColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeWidth: 2,
                    strokeOpacity: Math.random()
                });

                this.myMap.geoObjects.add(myPolygon);
            }
        },
        created() {
            ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
                this.myMap = new maps.Map('map', {
                    // center: [45.043330, 41.969101],
                    center: [55.73, 37.75],
                    zoom: 10,//13 ближе
                })
                this.drawPolygon(maps, [
                    [55.75, 37.50],
                    [55.80, 37.60],
                    [55.75, 37.70],
                    [55.70, 37.70],
                    [55.70, 37.50],
                    [55.75, 37.52],
                    [55.75, 37.68],
                    [55.65, 37.60]
                ])
            })
                .catch(error => console.log('Failed to load Yandex Maps', error));
        }
    }
</script>

<style lang="scss" scoped>
    #map {

        width: 75vmin;
        height: 75vmin;
    }
</style>