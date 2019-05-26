import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RSymptomService {
 
  apiURL= 'http://localhost:55144/api/';

  constructor(public http: HttpClient) {
    console.log('Rest api Service');
   }

   getSymptoms (){
    return new Promise(resolve =>{
      this.http.get(this.apiURL+'/Symptoms/Get').subscribe(data=> {
        resolve(data);
      }, err =>{
        console.log(err);
      });
    }); 
  }
}
