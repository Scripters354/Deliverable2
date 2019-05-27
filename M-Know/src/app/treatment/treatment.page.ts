import { Component, OnInit } from '@angular/core';
import {NavController} from '@ionic/angular';
import {TreatmentService} from '../Service/treatment.service';



@Component({
  selector: 'app-treatment',
  templateUrl: './treatment.page.html',
  styleUrls: ['./treatment.page.scss'],
})
export class TreatmentPage {
  Treatment :any;
  constructor( public navctrl: NavController, public restService:TreatmentService) {
    this.getTreatment();
  }


  getTreatment(){
    this.restService.getTreatment()
    .then(data=> {
      this.Treatment=data;
      console.log(this.Treatment);
    });
  }

  

}
