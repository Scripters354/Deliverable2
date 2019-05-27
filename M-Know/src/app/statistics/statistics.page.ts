import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { RStatistics, RStatisticsService } from '../Service/rstatistics.service';


@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.page.html',
  styleUrls: ['./statistics.page.scss'],
})
export class StatisticsPage {
  Statistics:any;
  constructor(public navctrl: NavController,public restService:RStatisticsService) { 
    this.getStatistics();
  }

  getStatistics(){
    this.restService.getStatistics()
    .then(data=> {
    this.Statistics = data;
      console.log(this.Statistics);
    });
  }
  

}
