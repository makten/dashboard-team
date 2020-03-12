import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
import axios from 'axios';
import * as globals from '../../globals';
//import { HubConnection } from '@aspnet/signalr-client';

@Component({
})

export default class SpotifyComponent extends Vue {
    artist: string = '';
    trackName: string = '';
    artWork: string = '';
    userName: string = '';  
    

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

    get hasCover(){
        return !!this.artWork;
    }

    get cover(){
        return this.artWork || '/dist/images/music__cover.jpg';
    }
   
}