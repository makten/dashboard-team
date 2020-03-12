var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from "vue";
import { Component, Watch } from "vue-property-decorator";
import * as _ from "lodash";
import * as globals from "../../globals";
let DashboardComponent = class DashboardComponent extends Vue {
    constructor() {
        super(...arguments);
        this.auth = globals.auth;
        this.userProfile = {};
        this.linkList = [
            {
                icon: '<i class="material-icons md-48" aria-hidden="true">assessment</i>',
                title: "Dashboard",
                link: "/",
                active: true
            },
            {
                icon: '<i class="material-icons md-48" aria-hidden="true">group_add</i>',
                title: "Customers",
                link: "/api/customers",
                active: false
            }
        ];
        this.forAdmin = [
            {
                icon: '<i class="material-icons md-48" aria-hidden="true">business</i>',
                title: "Departments",
                link: "/#",
                active: false
            },
            {
                icon: '<i class="material-icons md-48" aria-hidden="true">people</i>',
                title: "Employees",
                link: "/buildModel",
                active: false
            },
            {
                icon: '<i class="material-icons md-48" aria-hidden="true">security</i>',
                title: "Roles ",
                link: "/#",
                active: false
            }
        ];
        this.themeColor = { color: "#35475e", name: "Default", text: "#E3F2FD" };
        this.logo = "Hoperators";
        this.windowHeight = 0;
    }
    mounted() {
        this.$nextTick(function () {
            // window.addEventListener('resize', this.resizeSidebar);
            let profile = localStorage.getItem("profile");
            if (typeof profile !== "undefined" && profile !== null)
                this.userProfile = JSON.parse(profile);
            this.changeActive(window.location.pathname);
            globals.eventBroadcaster.$on("themeChanged", theme => {
                this.themeColor = theme;
            });
        });
    }
    changeActive(title) {
        this.linkList = _.map(this.linkList, link => {
            if (link.link == title) {
                link.active = true;
            }
            else {
                link.active = false;
            }
            return link;
        });
    }
    get sidebarSize() {
        //return this.$root.$el.offsetHeight;
        return 200;
    }
    onSidebarSize(sidebarZise, oldval) { }
};
__decorate([
    Watch("sideSize")
], DashboardComponent.prototype, "onSidebarSize", null);
DashboardComponent = __decorate([
    Component
], DashboardComponent);
export default DashboardComponent;
//# sourceMappingURL=sidebar.js.map