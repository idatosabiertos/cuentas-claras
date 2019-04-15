import { Component } from '@angular/core';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.scss']
})
export class DatabaseComponent {
  rows = [
    {
      name: 'Compras y contrataciones del Estado',
      description: 'Este conjunto de bases de datos continenen todas las compras y contrataciones que realizó el Estado uruguayo. El nivel de desagregación es por compra.',
      source: {src: 'https://www.comprasestatales.gub.uy', name: 'ACCE'},
      period: '2015-2018',
      files: [
        {src: '/ACCE/ACCE-2015.zip', name: 'ACCE-2015.zip'},
        {src: '/ACCE/ACCE-2016.zip', name: 'ACCE-2016.zip'},
        {src: '/ACCE/ACCE-2017.zip', name: 'ACCE-2017.zip'},
        {src: '/ACCE/ACCE-2018.zip', name: 'ACCE-2018.zip'}
      ]
    },
    {
      name: 'Registro Único de Proveedores del Estado (RUPE)',
      description: 'Este conjunto de bases de datos contiene información sobre las empresas registradas en el RUPE, sus representantes legales y sanciones.',
      source: {src: 'https://www.comprasestatales.gub.uy', name: 'ACCE'},
      period: '2013-2018 (Setiembre)',
      files: [
        {src: '/RUPE/RUPE-13-18.zip', name: 'RUPE-13-18.zip'},
      ]
    },
    {
      name: 'Personas Políticamente Expuestas',
      description: 'Este es una lista de personas consideradas políticamente expuestas por sus cargos políticos.',
      source: {src: 'https://www.bcu.gub.uy', name: 'BCU'},
      period: '2015-2017 (Junio)',
      files: [
        {src: '/BCU/BCU-2017.csv', name: 'BCU-2017.csv'}
      ]
    },
    {
      name: 'Empresas donante a la campaña electoral 2014',
      description: 'Este es una lista de las empresas que realizaron donaciones a partidos políticos para la campaña electoral 2014.',
      source: {src: 'https://fin-pol.github.com', name: 'Proyecto sobre Financiamiento de Partidos'},
      period: '2014',
      files: [
        {src: '/FIN-POL/FIN-POL-2014.csv', name: 'FIN-POL-2014.csv'}
      ]
    }

  ];
  columns = [
    {prop: 'name', name: 'Nombre', class: 'font-weight-bold'},
    {prop: 'description', name: 'Descripción'},
    {prop: 'period', name: 'Período'},
    {prop: 'source', name: 'Fuente', type: 'link'}
  ];

}
