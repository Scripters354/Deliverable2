import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import {RFAQsService } from '../Service/r-faqs.service';

@Component({
  selector: 'app-faqs',
  templateUrl: './faqs.page.html',
  styleUrls: ['./faqs.page.scss'],
})
export class FAQsPage {
  Symptoms :any;
constructor( public navctrl: NavController, public restService: RFAQsService) {
  this.getfaqs();
 }

 getfaqs(){
  this.restService.getfaqs()
  .then(data=> {
  this.Symptoms = data;
    console.log(this.Symptoms);
  });
}

  ngOnInit() {
  }

}
