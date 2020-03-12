var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
import * as $ from 'jquery';
import * as globals from '../../globals';
let ModalComponent = class ModalComponent extends Vue {
    constructor() {
        super(...arguments);
        this.styleObject = { width: this.width + '%', background: "#fff" };
    }
    mounted() {
        this.$nextTick(function () {
            $(`#${this.modalname}`).modal('show');
            $(`#${this.modalname}`).modal({
                backdrop: 'static',
                keyboard: true
            });
            $(`#${this.modalname}`).on("hidden.bs.modal", function () {
                globals.eventBroadcaster.$emit('closeModal');
            });
        });
    }
};
__decorate([
    Prop({ required: true, default: 'default-model' })
], ModalComponent.prototype, "modalname", void 0);
__decorate([
    Prop({ required: false, default: false })
], ModalComponent.prototype, "isDashboard", void 0);
__decorate([
    Prop({ required: false })
], ModalComponent.prototype, "width", void 0);
ModalComponent = __decorate([
    Component
], ModalComponent);
export default ModalComponent;
//# sourceMappingURL=modal.js.map