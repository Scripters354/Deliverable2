import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import {RFAQsService } from '../Service/r-faqs.service';

@Component({
  selector: 'app-faqs',
  templateUrl: './faqs.page.html',
  styleUrls: ['./faqs.page.scss'],
})
export class FAQsPage {
  faqs :any;
constructor( public navctrl: NavController, public restService: RFAQsService) {
  this.getfaqs();
 }

 getfaqs(){
  this.restService.getfaqs()
  .then(data=> {
  this.faqs = data;
    console.log(this.faqs);
  });
}

  ngOnInit() {
  }

}
