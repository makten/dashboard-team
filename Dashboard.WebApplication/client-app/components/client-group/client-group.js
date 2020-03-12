var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { relativeDate, formatDuration, formatDate } from './../../core/helper-util';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
let MemberComponent = class MemberComponent extends Vue {
    constructor() {
        super(...arguments);
        this.clientgroups = [];
        // validateBeforeSubmit() {
        //     this.$validator.validateAll().then(result => {
        //         if (result) {
        //             this.sending = true;
        //             let url = this.vehicleForm.formMode.method === 'put' ? `/api/vehicles/${this.vehicleForm.id}` : `/api/vehicles`
        //             this.vehicleForm[this.vehicleForm.formMode.method](url)
        //                 .then(data => {
        //                     this.queryResult.push(data)
        //                     this.sending = false;
        //                     this.$root.$router.push('/vehicle/new');
        //                     this.createEdit = false;
        //                 })
        //                 .catch(errors => {
        //                     this.sending = false;
        //                     this.errorBag = []
        //                     this.errorBag.push(errors)
        //                 });
        //         }
        //     });
        // }
        // setEdit(v) {
        //     this.createEdit = true;
        //     this.vehicleForm.id = v.id;
        //     this.vehicle.makeId = v.make.id;
        //     this.vehicle.modelId = v.model.id;
        //     this.vehicle.features = _.map(v.features, 'id')
        //     this.vehicle.isRegistered = v.isRegistered;
        //     this.vehicle.contact = v.contact;
        //     this.vehicle = this.vehicleForm;
        //     this.vehicleForm.formMode.method = 'put';
        //     this.vehicleForm.formMode.button = 'Update';
        //     this.changeVehicle();
        // }
        // deleteVehicle(vehicleId) {
        //     const token = localStorage.getItem("id_token");
        //     if (token != null)
        //         if (confirm("Are you sure you want to delete this item?"))
        //             axios.delete(`/api/vehicles/${vehicleId}`, {
        //                 headers: { 'Authorization': "Bearer " + token, 'Content-Type': 'application/json' }
        //             })
        //             .then(s => {
        //                 alert(`vehicle with ID ${vehicleId} has been deleted`);
        //                 this.queryResult.items = _.reject(this.queryResult.items, v => { return v['id'] === vehicleId  })
        //             })
        //             .catch(e => {
        //                 console.log(e)
        //             });
        // }
    }
    mounted() {
        //        const conn = new HubConnection('http://localhost:9000/teamEnvironmentUpdate');
        //        let vm = this;
        //        conn.on('UpdateTeamEnvironment', (data) => {
        //            vm.getClientGroups();
        //        })
        //
        //        conn.start()
        //            .then(() => console.log("Connected To TeamEnvironment"));
        //
        //        this.getClientGroups();
    }
    getClientGroups() {
        axios.get('/api/clientgroups').then(response => {
            this.clientgroups = response.data;
        }).catch(err => { });
    }
};
MemberComponent = __decorate([
    Component({
        methods: {
            relativeDate,
            formatDuration,
            formatDate
        }
    })
], MemberComponent);
export default MemberComponent;
//# sourceMappingURL=client-group.js.map