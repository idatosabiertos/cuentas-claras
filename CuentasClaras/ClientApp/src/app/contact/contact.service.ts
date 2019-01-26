import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) {
  }

  public sendEmail(data) {
    return this.http.post(`${environment.api_base_url}/email`, data);
  }
}
