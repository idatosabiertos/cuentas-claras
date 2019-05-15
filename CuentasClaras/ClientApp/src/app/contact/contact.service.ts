import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class ContactService {

  constructor(private http: HttpClient) {
  }

  public sendEmail(data) {
    let headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.post(`${environment.api_base_url}/api/mail/contact`, data,{
      headers: headers
    });
  }
}
