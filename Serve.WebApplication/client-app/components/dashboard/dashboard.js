var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
// import { auth } from './../../globals';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import vSelect from 'vue-select';
import axios from 'axios';
import Form from '../../core/Form';
import * as moment from 'moment';
import { authConfig } from './../../services/auth.config';
import Oidc from 'oidc-client';
moment.updateLocale('nl', {
    calendar: {
        lastDay: '[Yesterday]',
        sameDay: '[Today]',
        nextDay: '[Tomorrow]',
        lastWeek: '[last] dddd',
        nextWeek: 'dddd',
        sameElse: 'L',
    },
});
let DashboardComponent = class DashboardComponent extends Vue {
    constructor() {
        super(...arguments);
        this.client = new Oidc.OidcClient(authConfig);
        this.mng = new Oidc.UserManager({
            userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
            authority: "http://localhost:8080/auth/realms/master",
            client_id: "team-dashboard",
            redirect_uri: "http://localhost:9000",
            response_type: "id_token token",
            scope: "openid profile api1",
            post_logout_redirect_uri: "http://localhost:9000",
        });
        this.loadedUser = null;
        this.datetime = moment().format("MM-DD-YYYY");
        this.queryResult = {};
        this.user = { firstName: 'Hafiz', lastName: 'Abass', id: 2, avatar: '', teamId: 1 };
        this.newTODO = new Form({ title: '', sprintCode: '', description: '', goalStart: '', goalEnd: '', done: false, teamMemberId: '' });
        this.newEnvironment = new Form({ clientGroupId: '', clientgroup: null, name: '', description: '', extraDetails: '' });
        this.storyCodes = [
            "MGSYN-OV-FRC01",
            "MGSYN-OV-FRC08",
            "MGSYN-OV-FRC08",
            "MGING-OV-FRC16",
            "MGING-OV-FRC16",
            "MGRAB-OV-FRC03",
        ];
        this.clientLabels = [
            "Attens",
            "Tellius",
            "Syntrus"
        ];
        this.selectedCode = "";
        this.selectedLabel = "";
        this.todoList = [];
        this.environments = [];
        this.clients = [];
        this.selectClient = {};
    }
    mounted() {
        this.getGoals();
        this.getClients();
        this.getEnvironments();
    }
    test() {
        this.mng.signinRedirect().catch(err => { console.log(err); });
    }
    getUser() {
        let self = this;
        this.mng.signinRedirectCallback().then(function (user) {
            if (user) {
                console.log("User logged in", user.profile);
            }
            else {
                console.log("User not logged in");
            }
        }).catch(function (err) {
        });
    }
    signOuts() {
        var self = this;
        this.mng.signoutRedirect().then(function (resp) {
            //   self.signedIn = false
            console.log("signed out", resp);
        }).catch(function (err) {
            console.log(err);
        });
    }
    getGoals() {
        axios.get(`api/goals/${this.user.id}`).then(resp => {
            this.todoList = resp.data;
        }).catch(err => { });
    }
    getClients() {
        axios.get('api/clientgroups').then(resp => {
            this.clients = resp.data;
        }).catch(err => { });
    }
    getEnvironments() {
        axios.get('api/environments').then(resp => {
            this.environments = resp.data;
        }).catch(err => { });
    }
    addNewToDo() {
        if (this.newTODO.title != "" && this.selectedCode != "") {
            this.newTODO.teamMemberId = this.user.id;
            this.newTODO.sprintCode = this.selectedCode;
            axios.post('/api/goals', this.newTODO).then(resp => {
                console.log(resp.data);
                this.todoList.push(resp.data);
                this.clearInputs();
            }).catch(err => { console.log(err); });
        }
    }
    addEnvironment() {
        if (this.newEnvironment.name != '' && this.newEnvironment.code != '' && this.newEnvironment.clientgroup.id != '') {
            this.newEnvironment.clientGroupId = this.newEnvironment.clientgroup.id;
            axios.post('/api/environments', this.newEnvironment).then(resp => {
                console.log(resp.data);
                this.environments.push(resp.data);
                this.clearInputs();
            }).catch(err => { console.log(err); });
        }
    }
    clearInputs() {
        this.newEnvironment = { clientGroupId: '', clientgroup: null, name: '', description: '', extraDetails: '' };
        this.newTODO = { title: '', sprintCode: '', description: '', goalStart: '', goalEnd: '', done: false, teamMemberId: '' };
    }
    removeTodo(index, item) {
        axios.delete(`/api/goals/${item.id}`).then(resp => {
            this.todoList.splice(index, 1);
        }).catch(err => { });
        // this.todoList = _.reject(this.todoList, (i) => { return i.name == item.name })
    }
    removeEnvironment(index, item) {
        axios.delete(`/api/environments/${item.id}`).then(resp => {
            this.environments.splice(index, 1);
        }).catch(err => { });
    }
};
__decorate([
    Prop()
], DashboardComponent.prototype, "rows", void 0);
__decorate([
    Prop()
], DashboardComponent.prototype, "columns", void 0);
DashboardComponent = __decorate([
    Component({
        components: {
            'vSelect': vSelect,
            'datetimePicker': require('../../core/datetime-picker/datetime-picker.vue.html')
        }
    })
], DashboardComponent);
export default DashboardComponent;
//# sourceMappingURL=dashboard.js.map