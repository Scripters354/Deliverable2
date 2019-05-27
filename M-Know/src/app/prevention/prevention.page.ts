import { Component, OnInit } from '@angular/core';
import {NavController} from '@ionic/angular';
import {RPreventionService} from '../Service/rprevention.service';

@Component({
  selector: 'app-prevention',
  templateUrl: './prevention.page.html',
  styleUrls: ['./prevention.page.scss'],
})
export class PreventionPage {
  Prevention : any;
  constructor( public navctrl: NavController, public restService : RPreventionService) {
    this.getPrevention();
   }

  getPrevention(){
    this.restService.getPrevention()
    .then(data=> {
      this.Prevention=data;
      console.log(this.Prevention);
    });
  }
}
