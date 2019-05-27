import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class VisualizationsStatsService {


  constructor(private http: HttpClient) {
  }

  public getStats(years, orgId) {
    const range = this.range(years[0], years[1]);
    const params = new HttpParams().set('years', range.join(","));
    return this.http.get(`${environment.api_base_url}/api/buyer/${orgId}/stats`, {params: params});
  }

  public getBuyersList(){
    return this.http.get(`${environment.api_base_url}/api/buyer`);

  }

  private range(start, end) {
    const result = [];
    for (let i = start; i <= end; i++) {
      result.push(i);
    }
    return result;
  }

}
