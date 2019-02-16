import { Component } from '@angular/core';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.scss']
})
export class DatabaseComponent {
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

}
