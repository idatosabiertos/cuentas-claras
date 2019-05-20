import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class VisualizationsStatsService {


  constructor(private http: HttpClient) {
  }

  public getStats(years, orgId) {
    const params = new HttpParams().set('years', years.join(","));
    return this.http.get(`${environment.api_base_url}/api/organisation/buyers/stats/${orgId}`, {params: params});
  }
}
