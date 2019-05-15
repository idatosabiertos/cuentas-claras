import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class BuyingIndexStatsService {


  constructor(private http: HttpClient) {
  }

  public getIndex(year) {
    const params = new HttpParams().set('year', year);
    return this.http.get(`${environment.api_base_url}/api/stats/index`, {params: params});
  }
}
