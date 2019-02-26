import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeStatsService {

  constructor(private http: HttpClient) {
  }

  public getTopBuyers() {
    return this.http.get(`${environment.api_base_url}/api/stats/top-buyers`);
  }

  public getTopSuppliers() {
    return this.http.get(`${environment.api_base_url}/api/stats/top-suppliers`);
  }
}
