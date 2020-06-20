<template>
    <div id="map"></div>
</template>

<script>
    import ymaps from 'ymaps';

    ymaps.load('https://api-maps.yandex.ru/2.1/?lang=ru_RU&amp;apikey=f8732bc7-6ffa-445d-a447-abc4f837cdac').then((maps) => {
        var myMap = new maps.Map('map', {
            center: [45.043330, 41.969101],
            zoom: 13,
            // Добавим панель маршрутизации.
            controls: ['routePanelControl']
        });

        var control = myMap.controls.get('routePanelControl');

        // Зададим состояние панели для построения машрутов.
        control.routePanel.state.set({
            // Тип маршрутизации.
            type: 'pedestrian',
            // Включим возможность задавать пункт отправления в поле ввода.
            fromEnabled: true,
            // Адрес или координаты пункта отправления.
            from: 'Ставрополь, Мира 402',
            // Включим возможность задавать пункт назначения в поле ввода.
            toEnabled: true
            // Адрес или координаты пункта назначения.
            //to: '45.043330, 41.969101'
        });

        // Зададим опции панели для построения машрутов.
        control.routePanel.options.set({
            // Запрещаем показ кнопки, позволяющей менять местами начальную и конечную точки маршрута.
            allowSwitch: true,
            // Включим определение адреса по координатам клика.
            // Адрес будет автоматически подставляться в поле ввода на панели, а также в подпись метки маршрута.
            reverseGeocoding: true,
            // Зададим виды маршрутизации, которые будут доступны пользователям для выбора.
            types: {masstransit: false, pedestrian: true, taxi: false}
        });

        // Создаем кнопку, с помощью которой пользователи смогут менять местами начальную и конечную точки маршрута.
        var switchPointsButton = new maps.control.Button({
            data: {content: "Поменять местами", title: "Поменять точки местами"},
            options: {selectOnClick: false, maxWidth: 160}
        });
        // Объявляем обработчик для кнопки.
        switchPointsButton.events.add('click', function () {
            // Меняет местами начальную и конечную точки маршрута.
            control.routePanel.switchPoints();
        });
        myMap.controls.add(switchPointsButton);
    }).catch(error => console.log('Failed to load Yandex Maps', error));

    export default {
        name: "MapComponent"
    }
</script>

<style lang="scss" scoped>
    #map {
        width: 500px;
        height: 500px;
    }
</style>