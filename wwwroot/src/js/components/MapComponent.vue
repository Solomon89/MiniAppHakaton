<template>
    <div class="d-flex justify-content-center align-items-center w-100 h-100">
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
            drawPolygon(maps, coords, hintContent) {
                let myPolygon = new maps.Polygon([
                    coords
                ], {
                    hintContent: hintContent
                }, {
                    fillOpacity:0.4,
                    fillColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeWidth: 2,
                    strokeOpacity: Math.random()
                });

                this.myMap.geoObjects.add(myPolygon);
            },
            drawImage(ymaps, icon, coords, hintContent, balloonContent) {
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
            },
            drawPolyLine(ymaps, coords){
                // Создаем ломаную.
                let myPolyline = new ymaps.Polyline(coords, {}, {
                    // Задаем опции геообъекта.
                    // Цвет с прозрачностью.
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    // Ширину линии.
                    strokeWidth: 4,
                    // Максимально допустимое количество вершин в ломаной.
                    editorMaxPoints: 9999,
                });

                // Добавляем линию на карту.
                this.myMap.geoObjects.add(myPolyline);

            }
        },
        async created() {
            // let data = await $.ajax({
            //     type: 'POST',
            //     url: url,
            //     data: data,
            // });

            ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
                this.myMap = new maps.Map('map', {
                    // center: [45.043330, 41.969101],
                    center: [55.73, 37.75],
                    zoom: 13,//13 ближе
                    controls: []
                })
                this.myMap.behaviors.disable('scrollZoom');
                this.myMap.behaviors.disable('multiTouch');
                this.myMap.behaviors.disable('dblClickZoom');
                this.drawPolygon(maps, [
                    [55.75, 37.50],
                    [55.80, 37.60],
                    [55.75, 37.70],
                    [55.70, 37.70],
                    [55.70, 37.50],

                ], 'Зона комфорта')
                this.drawImage(maps, nikeIcon, [55.73, 37.75], 'Ивентовая башня', 'Захватите башню')
                this.drawImage(maps, fortressIcon, [55.79, 37.75], 'Башня', 'Захватите башню')
                this.drawPolyLine(maps,[
                    // Указываем координаты вершин.
                    [55.80, 37.50],
                    [55.80, 37.40],
                    [55.70, 37.50],
                    [55.70, 37.40]
                ])
            })
                .catch(error => console.log('Failed to load Yandex Maps', error));
        }
    }
</script>

<style lang="scss" scoped>
    #map {

        width: 100%;
        min-height: 600px;
        height: auto;
    }
</style>