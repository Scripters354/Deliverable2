import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class RHelpLineService {
  [x: string]: any;

  apiURL= 'http://localhost:55144/api/';

  constructor( public http: HttpClient) {
    console.log('RHelpLine api Service');
   }

   getCauses (){
    return new Promise(resolve =>{
      this.http.get(this.apiURL+'/Help_Line/Get').subscribe(data=> {
        resolve(data);
      }, err =>{
        console.log(err);
      });
    }); 
  }
}
