<template>
    <div class="d-flex justify-content-center align-items-center mt-5">
        <div id="map"></div>
    </div>
</template>

<script>
    import $ from "jquery";
    import ymaps from 'ymaps';
    import nikeIcon from '@/icons/circle-nike-round-icon-sports-icon-178227.png'
    import fortressIcon from '@/icons/fortress.png'

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
            drawPolygon(maps, coords,hintContent) {
                let myPolygon = new maps.Polygon([
                    coords
                ], {
                    hintContent: hintContent
                }, {
                    fillColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeWidth: 2,
                    strokeOpacity: Math.random()
                });

                this.myMap.geoObjects.add(myPolygon);
            },
            drawImage(ymaps, icon, coords,hintContent,balloonContent) {
                let myPlacemark = new ymaps.Placemark(coords, {
                    hintContent: hintContent,
                    balloonContent: balloonContent
                }, {
                    // Опции.
                    // Необходимо указать данный тип макета.
                    iconLayout: 'default#image',
                    // Своё изображение иконки метки.
                    iconImageHref: icon,
                    // Размеры метки.
                    iconImageSize: [30, 30],
                    // Смещение левого верхнего угла иконки относительно
                    // её "ножки" (точки привязки).
                    iconImageOffset: [0, 0]
                })
                
                this.myMap.geoObjects.add(myPlacemark);
            }
        },
        created() {
            ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
                this.myMap = new maps.Map('map', {
                    // center: [45.043330, 41.969101],
                    center: [55.73, 37.75],
                    zoom: 11,//13 ближе
                    controls: []
                })
                this.myMap.behaviors.disable('scrollZoom');
                this.drawPolygon(maps, [
                    [55.75, 37.50],
                    [55.80, 37.60],
                    [55.75, 37.70],
                    [55.70, 37.70],
                    [55.70, 37.50],
                  
                ],'Зона комфорта')
                this.drawImage(maps, nikeIcon, [55.73, 37.75], 'Ивентовая башня','Захватите башню')
                this.drawImage(maps, fortressIcon, [55.79, 37.75], 'Башня','Захватите башню')
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