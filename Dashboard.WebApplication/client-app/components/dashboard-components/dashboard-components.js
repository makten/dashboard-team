var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from 'vue-property-decorator';
import Vue from 'vue';
import * as globals from '../../globals';
let MainDashboardComponent = class MainDashboardComponent extends Vue {
    constructor() {
        super(...arguments);
        this.authenticated = globals.authenticated;
        this.auth = globals.auth;
        this.login = globals.login;
        this.logout = globals.logout;
        this.fullScreen = false;
        this.weatherCity = 'Deventer';
    }
    mounted() {
        globals.eventBroadcaster.$on('changeRoute', (routeLink) => {
            this.$root.$router.push(routeLink);
        });
        globals.eventBroadcaster.$on('authChange', (authState) => {
            this.authenticated = authState.authenticated;
        });
    }
};
MainDashboardComponent = __decorate([
    Component({
        components: {
            memberComponent: require('../member/member.vue.html'),
            environmentComponent: require('../client-group/client-group.vue.html'),
            dashboardComponent: require('../dashboard/dashboard.vue.html'),
            weatherComponent: require('../weather/weather.vue.html'),
            jenkinsComponent: require('../jenkins/jenkins-stats.vue.html'),
            spotifyComponent: require('../music/spotify.vue.html'),
            FooterComponent: require('../footer/footer.vue.html'),
            HomeComponent: require('../home/home.vue.html'),
        }
    })
], MainDashboardComponent);
export default MainDashboardComponent;
//# sourceMappingURL=dashboard-components.js.map