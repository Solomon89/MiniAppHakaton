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
                maps: undefined
            }
        },
        props: {
            location: Object,
            vkId: Number,
            npcInfo: Object
        },
        methods: {
            drawPolygon(maps, coords, color, hintContent) {
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
            drawImage(ymaps, icon, coords, hintContent, color, id, type) {
                let myPlacemark = new ymaps.Placemark(coords, {
                    hintContent: hintContent,
                    // balloonContent: balloonContent
                }, {
                    hasBalloon: false,
                    iconLayout: 'default#image',
                    iconImageHref: icon,
                    iconImageSize: [30, 30],
                    iconImageOffset: [-15, -15]
                })
                myPlacemark.events.add('click', (e) => {

                    this.myMap.balloon.open(
                        // Позиция балуна
                        e.get("coords"), {
                            // Свойства балуна:
                            // контент балуна
                            contentBody: `<div>Приступить к выполнению <br>этой задачи?</div><button data-color="${color}" data-event-id="${id}" data-event-type="${type}" class="taskSelectionConfirmation btn btn-info">Приступить</button>`
                        }
                    )

                    // let coords = e.get('coords');
                    // alert(coords.join(', '));
                });
                this.myMap.geoObjects.add(myPlacemark);
            },
            drawPolyLine(ymaps, coords, color) {
                let myPolyline = new ymaps.Polyline(coords, {}, {
                    strokeColor: color,
                    strokeWidth: 3,
                    editorMaxPoints: 9999,
                });

                this.myMap.geoObjects.add(myPolyline);

            },
            drawCircle(ymaps, coords, radius, color, hintContent, balloonContent) {
                let myCircle = new ymaps.Circle([
                    coords,
                    radius * 50
                ], {
                    balloonContent: balloonContent,
                    hintContent: hintContent
                }, {
                    draggable: false,
                    fillColor: color,
                    strokeColor: color,
                    fillOpacity: 0.4,
                    strokeOpacity: 0.4,
                    strokeWidth: 2
                });

                this.myMap.geoObjects.add(myCircle);
            }
        },
        async created() {

            ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
                this.maps = maps
                this.myMap = new maps.Map('map', {
                    // center: [this.location.lat, this.location.long],
                    center: [55.73, 37.75],
                    zoom: 13,//13 ближе
                    controls: []
                })
                this.myMap.behaviors.disable('scrollZoom')
                this.myMap.behaviors.disable('multiTouch')
                this.myMap.behaviors.disable('dblClickZoom')
                for (let elem of this.npcInfo.buildings) {
                    let color = '#808080'
                    if ((elem.user !== undefined && elem.user !== null) && (elem.user.color !== undefined && elem.user.color !== null)) {
                        color = elem.user.color
                    }
                    this.drawImage(maps, '/src/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, color, elem.id)
                    this.drawCircle(maps, [elem.lat, elem.lon], elem.radius, color)
                }
                for (let elem of this.npcInfo.mobs) {
                    let color = '#808080'
                    if ((elem.user !== undefined && elem.user !== null) && (elem.user.color !== undefined && elem.user.color !== null)) {
                        color = elem.user.color
                    }
                    this.drawImage(maps, '/src/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, color, elem.id)
                }
                for (let elem of this.npcInfo.events) {
                    let color = '#808080'
                    if ((elem.user !== undefined && elem.user !== null) && (elem.user.color !== undefined && elem.user.color !== null)) {
                        color = elem.user.color
                    }
                    this.drawImage(maps, '/src/icons/' + elem.icon, [elem.lat, elem.lon], elem.name, color, elem.id)
                }
            })
                .catch(error => console.log('Failed to load Yandex Maps', error));
        },
        mounted() {
            setInterval(() => {
                $('.taskSelectionConfirmation').on('click', async (e) => {
                    let target = $(e.target);
                    let id = target.attr('data-event-id')
                    let type = target.attr('data-event-type')
                    let color = target.attr('data-color')
                    let data = await $.ajax({
                        type: 'GET',
                        url: `/Api/MapController/EventQuest?eventId=${id}&&type=${type}`,
                    });
                    this.drawPolyLine(this.maps, data, color)
                    $('balloon__close-button').click()
                })
            }, 1000)
        }
    }
</script>

<style lang="scss" scoped>
    #map {
        width: 100vw;
        height: 100vh;
    }
</style>