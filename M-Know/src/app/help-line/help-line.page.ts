import { Component, OnInit } from '@angular/core';
import {RHelpLineService } from '../r-help-line.service';
import { NavController } from '@ionic/angular';


@Component({
  selector: 'app-help-line',
  templateUrl: './help-line.page.html',
  styleUrls: ['./help-line.page.scss'],
})
export class HelpLinePage {
  help :any;
constructor( public navctrl: NavController, public restService: RHelpLineService) {
  this.gethelp();
 }

 gethelp(){
  this.restService.gethelp()
  .then(data=> {
  this.help = data;
    console.log(this.help);
  });
}

  ngOnInit() {
  }

}
