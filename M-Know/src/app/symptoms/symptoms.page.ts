import { Component } from '@angular/core';
import { NavController } from '@ionic/angular';
import { RSymptomService } from '../Service/rsymptom.service';

@Component({
  selector: 'app-symptoms',
  templateUrl: './symptoms.page.html',
  styleUrls: ['./symptoms.page.scss'],
})
export class SymptomsPage  {
    Symptoms :any;
  constructor( public navctrl: NavController, public restService: RSymptomService) {
    this.getSymptoms();
   }
   
  getSymptoms(){
    this.restService.getSymptoms()
    .then(data=> {
    this.Symptoms = data;
      console.log(this.Symptoms);
    });
  }

}
