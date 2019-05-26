import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class RestService {
  apiURL= 'http://localhost:55144/api/';

  constructor(public http: HttpClient) { 
    console.log('Rest api Service');
  }
  getAboutMalaria (){
    return new Promise(resolve =>{
      this.http.get(this.apiURL+'/About_Malaria/Get').subscribe(data=> {
        resolve(data);
      }, err =>{
        console.log(err);
      });
    }); 
  }
}
