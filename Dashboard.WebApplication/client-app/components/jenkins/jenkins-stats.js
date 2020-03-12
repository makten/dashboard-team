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
import jenkins from './../../services/jenkins-service';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
let JenkinsComponent = class JenkinsComponent extends Vue {
    // @Prop({type: String, default: 'DD/MM'})
    // dateFormat;
    // @Prop({ type: String, default: 'Europe/Amsterdam' })
    // timeZone;
    // @Prop({type: String, default: 'HH:mm:ss'})
    // timeFormat: string;
    // @Prop({ type: String })
    // weatherCity: any;
    // date = '';
    // time = '';
    // weather: any = {
    //     temperature: '',
    //     iconClass: '',
    // }
    created() {
        // this.refreshTime();
        // setInterval(this.refreshTime, 1000);
        // this.fetchStatistics();
        // setInterval(this.fetchStatistics, 15 * 60 * 1000);
    }
    refreshTime() {
        // this.date = moment().tz(this.timeZone).format(this.dateFormat);
        // this.time = moment().tz(this.timeZone).format(this.timeFormat);
    }
    fetchStatistics() {
        return __awaiter(this, void 0, void 0, function* () {
            var teamx = encodeURI("Eile Mit Weile");
            var pipelinex = encodeURI("Stabilisatie-teststraat-ING");
            var environmentx = "ING";
            const statistics = yield jenkins.statistics(teamx, pipelinex, environmentx);
            console.log(statistics);
            // this.weather.temperature = conditions.temp;
            // this.weather.iconClass = `wi-yahoo-${conditions.code}`;
        });
    }
    getEnvironments() {
        axios.get('/api/environments').then(response => {
            // this.environments = response.data;
        }).catch(err => { });
    }
};
JenkinsComponent = __decorate([
    Component({
        methods: {
            relativeDate,
            formatDuration,
            formatDate
        }
    })
], JenkinsComponent);
export default JenkinsComponent;
//# sourceMappingURL=jenkins-stats.js.map