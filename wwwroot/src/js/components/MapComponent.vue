<template>
    <div class="d-flex justify-content-center align-items-center w-100 h-100">
        <div id="map"></div>
    </div>
</template>

<script>
    import $ from "jquery";
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
                ],
                state: 1
            }
        },
        props: {
            location: Object,
            vkId: Number,
            npcInfo: Array
        },
        methods: {
            drawPolygon(maps, coords, hintContent) {
                let myPolygon = new maps.Polygon([
                    coords
                ], {
                    hintContent: hintContent
                }, {
                    fillOpacity: 0.4,
                    fillColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeWidth: 2,
                    strokeOpacity: Math.random()
                });

                this.myMap.geoObjects.add(myPolygon);
            },
            drawImage(ymaps, icon, coords, hintContent, color, id) {
                let myPlacemark = new ymaps.Placemark(coords, {
                    hintContent: hintContent,
                    // balloonContent: balloonContent
                }, {
                    hasBalloon: false,
                    iconLayout: 'default#image',
                    iconImageHref: icon,
                    iconImageSize: [30, 30],
                    iconImageOffset: [0, 0]
                })
                myPlacemark.events.add('click', (e) => {
                    console.log(id)
                    this.myMap.balloon.open(
                        // Позиция балуна
                        e.get("coords"), {
                            // Свойства балуна:
                            // контент балуна
                            contentBody: `<div>Значение ${e.get("coords")}</div>`
                        }
                    )
                    // var coords = e.get('coords');
                    // alert(coords.join(', '));
                });
                this.myMap.geoObjects.add(myPlacemark);
            },
            drawPolyLine(ymaps, coords) {
                let myPolyline = new ymaps.Polyline(coords, {}, {
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeWidth: 4,
                    editorMaxPoints: 9999,
                });

                this.myMap.geoObjects.add(myPolyline);

            },
            drawCircle(ymaps, coords, radius, hintContent, balloonContent) {
                let myCircle = new ymaps.Circle([
                    coords,
                    radius
                ], {
                    balloonContent: balloonContent,
                    hintContent: hintContent
                }, {
                    draggable: false,
                    fillColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    strokeColor: this.colors[Math.floor((Math.random() * this.colors.length))],
                    fillOpacity: 0.4,
                    strokeOpacity: 0.4,
                    strokeWidth: 2
                });

                this.myMap.geoObjects.add(myCircle);
            }
        },
        async created() {

            ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
                this.myMap = new maps.Map('map', {
                    // center: [this.location.lat, this.location.long],
                    center: [55.73, 37.75],
                    zoom: 13,//13 ближе
                    controls: []
                })
                this.myMap.behaviors.disable('scrollZoom');
                this.myMap.behaviors.disable('multiTouch');
                this.myMap.behaviors.disable('dblClickZoom');

                for (let elem of this.npcInfo.buildings) {
                    this.drawImage(maps, '/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, elem.user.color, elem.id)
                }
                for (let elem of this.npcInfo.mobs) {
                    this.drawImage(maps, '/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, elem.user.color, elem.id)
                }
                for (let elem of this.npcInfo.events) {
                    this.drawImage(maps, '/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, elem.user.color, elem.id)
                }
                // this.drawPolygon(maps, [
                //     [55.75, 37.50],
                //     [55.80, 37.60],
                //     [55.75, 37.70],
                //     [55.70, 37.70],
                //     [55.70, 37.50],
                //
                // ], 'Зона комфорта')
                // this.drawImage(maps, nikeIcon, [55.73, 37.75], 'Ивентовая башня', 'Захватите башню')
                // this.drawImage(maps, fortressIcon, [55.79, 37.75], 'Башня', 'Захватите башню')
                // this.drawPolyLine(maps, [
                //     // Указываем координаты вершин.
                //     [55.80, 37.50],
                //     [55.80, 37.40],
                //     [55.70, 37.50],
                //     [55.70, 37.40]
                // ])
            })
                .catch(error => console.log('Failed to load Yandex Maps', error));
        }
    }
</script>

<style lang="scss" scoped>
    #map {
        width: 100vw;
        height: 100vh;
    }
</style>