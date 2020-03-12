import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
//import VeeValidate from 'vee-validate';
import * as globals from './globals';


Vue.use(VueRouter);
//Vue.use(VeeValidate);

import moment from 'moment';

moment.updateLocale('en', {
    calendar: {
        lastDay: '[Yesterday]',
        sameDay: '[Today]',
        nextDay: '[Tomorrow]',
        lastWeek: '[last] dddd',
        nextWeek: 'dddd',
        sameElse: 'L',
    },
});

const routes = [
    { path: '/callback', component: require('./components/dashboard/dashboard.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    mounted() {

    },
    render: (h: any) => h(require('./components/dashboard-components/dashboard-components.vue.html'))
});