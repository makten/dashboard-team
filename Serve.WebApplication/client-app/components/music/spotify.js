var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from 'vue-property-decorator';
import Vue from 'vue';
//import { HubConnection } from '@aspnet/signalr-client';
let SpotifyComponent = class SpotifyComponent extends Vue {
    constructor() {
        super(...arguments);
        this.artist = '';
        this.trackName = '';
        this.artWork = '';
        this.userName = '';
    }
    mounted() {
        //        const conn = new HubConnection('http://localhost:9000/UpdateTrack');
        //        let vm = this;
        //        conn.on('UpdateTrack', (data) => {
        //            vm.artist = data.Artist;
        //            vm.trackName = data.TrackName;
        //            vm.artWork = data.ArtWork;
        //            vm.userName = data.UserName;
        //        })
        //
        //        conn.start()
        //            .then(() => console.log("Connected To PlayerHub"));
    }
    get currentlyPlaying() {
        return !!this.artist;
    }
    get hasCover() {
        return !!this.artWork;
    }
    get cover() {
        return this.artWork || '/dist/images/music__cover.jpg';
    }
};
SpotifyComponent = __decorate([
    Component({})
], SpotifyComponent);
export default SpotifyComponent;
//# sourceMappingURL=spotify.js.map