var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { relativeDate, formatDuration, formatDate } from './../../core/helper-util';
import weather from './../../services/weather-service';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as moment from 'moment-timezone';
let WeatherComponent = class WeatherComponent extends Vue {
    constructor() {
        super(...arguments);
        this.date = '';
        this.time = '';
        this.weather = {
            temperature: '',
            iconClass: '',
        };
    }
    created() {
        this.refreshTime();
        setInterval(this.refreshTime, 1000);
        this.fetchWeather();
        setInterval(this.fetchWeather, 15 * 60 * 1000);
    }
    refreshTime() {
        this.date = moment().tz(this.timeZone).format(this.dateFormat);
        this.time = moment().tz(this.timeZone).format(this.timeFormat);
    }
    fetchWeather() {
        return __awaiter(this, void 0, void 0, function* () {
            const conditions = yield weather.conditions(this.weatherCity);
            this.weather.temperature = conditions.temp;
            this.weather.iconClass = `wi-yahoo-${conditions.code}`;
        });
    }
};
__decorate([
    Prop({ type: String, default: 'DD/MM' })
], WeatherComponent.prototype, "dateFormat", void 0);
__decorate([
    Prop({ type: String, default: 'Europe/Amsterdam' })
], WeatherComponent.prototype, "timeZone", void 0);
__decorate([
    Prop({ type: String, default: 'HH:mm:ss' })
], WeatherComponent.prototype, "timeFormat", void 0);
__decorate([
    Prop({ type: String })
], WeatherComponent.prototype, "weatherCity", void 0);
WeatherComponent = __decorate([
    Component({
        methods: {
            relativeDate,
            formatDuration,
            formatDate
        }
    })
], WeatherComponent);
export default WeatherComponent;
//# sourceMappingURL=weather.js.map