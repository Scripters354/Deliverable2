import { Component } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public appPages = [
    {
      title: 'Home',
      url: '/home',
      icon: 'home'
    },
    
    {
      title: 'About',
      url: '/about',
      icon: 'about'
    },
    {
      title: 'Cause',
      url: '/cause',
      icon: 'cause'
    },
    {
      title: 'Symptoms',
      url: '/symptoms',
      icon: 'symptoms'
    },
    {
      title:'Treatment',
      url: '/treatment',
      icon: 'treatment'
    },
    {
      title:'Prevention',
      url: '/prevention',
      icon: 'prevention'
    },
    {
      title:'Statistics',
      url:'/statistics',
      icon:'statistics'
    }


  ];

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }
}
