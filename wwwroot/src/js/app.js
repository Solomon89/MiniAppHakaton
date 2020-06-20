import '@/scss/styles.scss';
import Vue from 'vue';
import BaseComponent from "@/js/components/BaseComponent";

new Vue({
    data: {},
    template: '<base-component></base-component>',
    components: {BaseComponent}

}).$mount('#app');


