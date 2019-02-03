import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-buying-index',
  templateUrl: './buying-index.component.html',
  styleUrls: ['./buying-index.component.scss']
})
export class BuyingIndexComponent implements OnInit {

  public data = [
    {title: 'Presidencia', rating: 4.5, description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'},
    {
      title: 'Ministerio de Economia',
      rating: 4.0,
      description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'
    },
    {
      title: 'Ministerio de Industria, Energía y Minería',
      rating: 3.5,
      description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'
    },
    {
      title: 'Ministerio de Salud Publica',
      rating: 2.5,
      description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'
    },
    {
      title: 'Ministerio de Transporte',
      rating: 2.0,
      description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'
    },
    {
      title: 'Intendencia Municipal de Montevideo',
      rating: 1.5,
      description: 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit...'
    }
  ];
  public indexDataGroup = [];

  constructor() {
  }

  ngOnInit() {
    this.splitArray();
  }

  private splitArray() {
    const size = 2;
    while (this.data.length > 0) {
      this.indexDataGroup.push(this.data.splice(0, size));
    }
  }

}
