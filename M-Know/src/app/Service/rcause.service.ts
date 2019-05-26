import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RCauseService {

  apiURL= 'http://localhost:55144/api/';

  constructor( public http: HttpClient) {
    console.log('Rcause api Service');
   }

   getCauses (){
    return new Promise(resolve =>{
      this.http.get(this.apiURL+'/Causes/Get').subscribe(data=> {
        resolve(data);
      }, err =>{
        console.log(err);
      });
    }); 
  }
}
