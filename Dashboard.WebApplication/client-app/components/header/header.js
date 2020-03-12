var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as globals from '../../globals';
import Helpers from '../../core/Helpers';
let HeaderComponent = class HeaderComponent extends Vue {
    constructor() {
        super(...arguments);
        this.userProfile = {};
        this.themes = [
            { color: '#35475e', name: 'Default', text: '#E3F2FD' },
            { color: '#5E35B1', name: 'Purple', text: '#E1F5FE' },
            { color: '#00695C', name: 'Green', text: '#E1F5FE' },
            { color: '#E53935', name: 'Red', text: '#E1F5FE' },
            { color: '#1E88E5', name: 'Blue', text: '#E1F5FE' },
            { color: '#BDBDBD', name: 'Light Grey', text: '#424242' }
        ];
        this.themeColor = { color: '#35475e', name: 'Default', text: "#E3F2FD" };
    }
    mounted() {
        //Testing textSummarizer...
        let v = "Hello world of people and programmers who are busy learning and really really really";
        console.log(Helpers.textSummerizer(v, 60));
        console.log(Helpers.passwordGenerator());
        let profile = localStorage.getItem('profile');
        if (typeof profile !== 'undefined' && profile !== null)
            this.userProfile = JSON.parse(profile);
    }
    setTheme(theme) {
        this.themeColor = theme;
        globals.eventBroadcaster.$emit('themeChanged', theme);
    }
};
__decorate([
    Prop({})
], HeaderComponent.prototype, "auth", void 0);
__decorate([
    Prop({})
], HeaderComponent.prototype, "authenticated", void 0);
HeaderComponent = __decorate([
    Component
], HeaderComponent);
export default HeaderComponent;
//# sourceMappingURL=header.js.map