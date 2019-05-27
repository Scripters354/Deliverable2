import { Component } from '@angular/core';
import { NavController } from '@ionic/angular';
import { RestService } from '../Service/rest.service';

@Component({
  selector: 'app-home',
  templateUrl:'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
   
  About_Malaria: any;
  constructor(public navctrl: NavController, public restService: RestService) {
    this.getAboutMalaria();
  }

  getAboutMalaria(){
    this.restService.getAboutMalaria()
    .then(data=> {
    this.About_Malaria = data;
      console.log(this.About_Malaria);
    });
  }

}
