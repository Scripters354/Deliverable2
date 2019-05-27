import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TreatmentService {

  apiURL='http://localhost:55144/api/';


  constructor(public http: HttpClient) {
    console.log('Treatment api Service');
   }

   getTreatment (){
     return new Promise(resolve =>{
       this.http.get(this.apiURL+'/Treatment/Get').subscribe(data=> {
         resolve(data);
       }, err=>{
         console.log(err);
       });
     });
   }
}
