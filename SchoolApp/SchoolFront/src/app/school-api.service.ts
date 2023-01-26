import { Injectable } from '@angular/core';
import { MotivationComponent } from './motivation/motivation.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SchoolApiService {

  
  readonly baseUrl = "https://localhost:7243/api/Course/15"
  // readonly searchNurseDetailsUrl = "SearchNurseDetails";

  constructor(private http: HttpClient) { }

  postIdDetailsSearch(zebra?: number) {
    // zebra = 2;
    return this.http.get<any>(this.baseUrl);
    // return this.http.post<any>(this.baseUrl + this.searchNurseDetailsUrl, zebra);
   
  };
}
