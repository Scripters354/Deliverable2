import { Component } from '@angular/core';
import { RCauseService } from '../Service/rcause.service';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-cause',
  templateUrl: './cause.page.html',
  styleUrls: ['./cause.page.scss'],
})
export class CausePage  {
   
  Causes :any;
  constructor(public navctrl: NavController, public restService: RCauseService) { 
    this.getCauses();
  }

  
  getCauses(){
    this.restService.getCauses()
    .then(data=> {
    this.Causes = data;
      console.log(this.Causes);
    });
  }


}
