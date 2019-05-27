import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class RPreventionService {

  apiURL= 'http://localhost:55144/api/';

  constructor(public http:HttpClient) {
    console.log('Rest api Service');
   }

   getPrevention(){
     return new Promise(resolve=>{
       this.http.get(this.apiURL+'/Prevention/Get').subscribe(data=> {
         resolve(data);
       },err =>{
         console.log(err);
       });
    });
  }
       
}
