var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
let DashboardComponent = class DashboardComponent extends Vue {
    constructor() {
        super(...arguments);
        this.queryResult = {};
    }
    mounted() {
        // this.getAllVehicles();
    }
    getAllVehicles() {
        axios.get("api/dashboard").then(response => {
            this.queryResult = response.data;
        })
            .catch(error => { });
    }
    get gridTemplate() {
        return `grid-template: repeat(${this.rows}, 1fr) / repeat(${this.columns}, 1fr);`;
    }
};
__decorate([
    Prop()
], DashboardComponent.prototype, "rows", void 0);
__decorate([
    Prop()
], DashboardComponent.prototype, "columns", void 0);
DashboardComponent = __decorate([
    Component
], DashboardComponent);
export default DashboardComponent;
//# sourceMappingURL=dashboard.js.map