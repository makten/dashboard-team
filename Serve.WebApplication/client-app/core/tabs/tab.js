var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
let TabComponent = class TabComponent extends Vue {
    constructor() {
        super(...arguments);
        this.isActive = false;
    }
    mounted() {
        this.isActive = this.selected;
    }
    get href() {
        return '#' + this.name.toLowerCase().replace(/ /g, '-');
    }
};
__decorate([
    Prop({ required: true })
], TabComponent.prototype, "name", void 0);
__decorate([
    Prop({ default: false })
], TabComponent.prototype, "selected", void 0);
TabComponent = __decorate([
    Component
], TabComponent);
export default TabComponent;
//# sourceMappingURL=tab.js.map