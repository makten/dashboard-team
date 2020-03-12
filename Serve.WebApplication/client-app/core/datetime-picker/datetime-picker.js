var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
import * as moment from 'moment';
let DatetimePicker = class DatetimePicker extends Vue {
    mounted() {
        this.$nextTick(function () {
            $(this.$refs.datetimeinput).datepicker();
        });
    }
};
__decorate([
    Prop({ required: false, default: true })
], DatetimePicker.prototype, "model", void 0);
__decorate([
    Prop({ required: false, default: false })
], DatetimePicker.prototype, "name", void 0);
__decorate([
    Prop({ required: false, default: moment() })
], DatetimePicker.prototype, "placeholder", void 0);
DatetimePicker = __decorate([
    Component
], DatetimePicker);
export default DatetimePicker;
//# sourceMappingURL=datetime-picker.js.map