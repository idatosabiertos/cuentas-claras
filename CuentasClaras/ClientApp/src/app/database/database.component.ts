import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/internal/operators';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.scss']
})
export class DatabaseComponent implements OnInit {
  rows = [
    {
      name: 'Releases',
      description: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fugit, error amet numquam iure.',
      file: 'releases.csv'
    },
    {
      name: 'Items',
      description: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fugit, error amet numquam iure.',
      file: 'awa_items.csv'
    },
    {
      name: 'Suppliers',
      description: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fugit, error amet numquam iure.',
      file: 'awa_suppliers.csv'
    },

  ];
  columns = [
    {prop: 'name', name: 'Nombre'},
    {prop: 'description', name: 'Descripción'},
  ];

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
  }


  download(file: string, year: string) {
    let headerOptions = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/octet-stream',
    });

    let requestOptions = {headers: headerOptions, responseType: 'blob' as 'blob'};
    this.http.get(`assets/database/${year}/${file}`, requestOptions).pipe(map((data: any) => {

      let blob = new Blob([data], {
        type: 'application/octet-stream'
      });
      var link = document.createElement('a');
      link.href = window.URL.createObjectURL(blob);
      link.download = `${year}-${file}.csv`;
      link.click();
      window.URL.revokeObjectURL(link.href);

    })).subscribe();
  }

}
