import { Component } from '@angular/core';

@Component({
  selector: 'app-buying-index',
  templateUrl: './buying-index.component.html',
  styleUrls: ['./buying-index.component.scss']
})
export class BuyingIndexComponent {
  columns = [
    {prop: 'entity', name: 'Ente'},
  ];
  rows = [
    {
      entity: 'Presidencia',
      rating: 4.5,
    },
    {
      entity: 'Ministerio de Economia',
      rating: 4.0,
    },
    {
      entity: 'Ministerio de Industria, Energía y Minería',
      rating: 3.5,
    },
    {
      entity: 'Ministerio de Salud Publica',
      rating: 2.5,
    },
    {
      entity: 'Ministerio de Transporte',
      rating: 2.0,
    },
    {
      entity: 'Intendencia Municipal de Montevideo',
      rating: 1.5,
    }
  ];

}
