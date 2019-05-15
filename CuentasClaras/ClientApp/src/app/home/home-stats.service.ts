import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class HomeStatsService {

  constructor(private http: HttpClient) {
  }

  public getTopBuyers(year) {
    const params = new HttpParams().set('year', year);
    return this.http.get(`${environment.api_base_url}/api/stats/top-buyers`, {params: params});
  }

  public getTopSuppliers(year) {
    const params = new HttpParams().set('year', year);
    return this.http.get(`${environment.api_base_url}/api/stats/top-suppliers`, {params: params});
  }


  public getTopItems(year) {
    const params = new HttpParams().set('year', year);
    return this.http.get(`${environment.api_base_url}/api/stats/top-items`, {params: params});
  }

  public getListofItems() {
    return this.http.get(`${environment.api_base_url}/api/stats/items-classification`);

  }

  public getItemPrices(item) {
    return this.http.get(`${environment.api_base_url}/api/stats/items-classification/${item}`);
  }
}
