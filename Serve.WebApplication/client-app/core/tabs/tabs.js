var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from 'vue-property-decorator';
import Vue from 'vue';
let TabsComponent = class TabsComponent extends Vue {
    constructor() {
        super(...arguments);
        this.tabs = [];
    }
    created() {
        this.tabs = this.$children;
        // Listen to currently selected tab from Dashboard.vue
        this.$on('setTab', this.selectTab);
    }
    selectTab(selectTab) {
        // console.log(selectTab.tab, selectTab.ucs)
        this.tabs.forEach(tab => {
            tab.isActive = (tab.href == selectTab);
        });
        // window.location.hash = selectTab;
    }
};
TabsComponent = __decorate([
    Component
], TabsComponent);
export default TabsComponent;
//# sourceMappingURL=tabs.js.map