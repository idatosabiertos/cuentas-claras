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
        {src: '/CCE/2015.zip', name: 'ACCE-2015'},
        {src: '/CCE/2016.zip', name: 'ACCE-2016'},
        {src: '/CCE/2017.zip', name: 'ACCE-2017'},
        {src: '/CCE/2018.zip', name: 'ACCE-2018'}
      ]
    },
    {
      name: 'Registro Único de Proveedores del Estado (RUPE)',
      description: 'Este conjunto de bases de datos contiene información sobre las empresas registradas en el RUPE, sus representantes legales y sanciones.',
      source: {src: 'https://www.comprasestatales.gub.uy', name: 'ACCE'},
      period: '2013-2018 (Setiembre)',
      files: [
        {src: '/CCE/2015.zip', name: 'RUPE-2013'},
        {src: '/CCE/2015.zip', name: 'RUPE-2014'},
        {src: '/CCE/2015.zip', name: 'RUPE-2015'},
        {src: '/CCE/2016.zip', name: 'RUPE-2016'},
        {src: '/CCE/2017.zip', name: 'RUPE-2017'},
        {src: '/CCE/2018.zip', name: 'RUPE-2018'}
      ]
    },
    {
      name: 'Personas Políticamente Expuestas',
      description: 'Este es una lista de personas consideradas políticamente expuestas por sus cargos políticos.',
      source: {src: 'https://www.bcu.gub.uy', name: 'BCU'},
      period: '2015-2017 (Junio)',
      files: [
        {src: '/CCE/2015.zip', name: 'BCU-2015'},
        {src: '/CCE/2016.zip', name: 'BCU-2016'},
        {src: '/CCE/2017.zip', name: 'BCU-2017'},
      ]
    },
    {
      name: 'Empresas donante a la campaña electoral 2014',
      description: 'Este es una lista de las empresas que realizaron donaciones a partidos políticos para la campaña electoral 2014.',
      source: {src: 'https://fin-pol.github.com', name: 'Proyecto sobre Financiamiento de Partidos'},
      period: '2014',
      files: [
        {src: '/CCE/2015.zip', name: 'FIN-POL-2014'}
      ]
    },
    {
      name: 'Lista de Paraísos Fiscales',
      description: 'Esta es una lista de países catalogados como paraísos fiscales por la Unión Europea.',
      source: {src: 'https://ec.europa.eu/taxation_customs/tax-common-eu-list_en', name: 'Unión Europea'},
      period: '2017',
      files: [
        {src: '/CCE/2015.zip', name: 'UE-2017'},
      ]
    },
    {
      name: 'Índice de Transparencia en las Contrataciones  Públicas',
      description: 'Esta base de datos contiene los resultados del Índice de Transparencia en las Contrataciones Públicas elaborado para este proyecto. El nivel de desagregación es por Unidad Ejecutora.',
      source: {src: '#', name: 'Cuentas Claras'},
      period: '2015-2018',
      files: [
        {src: '/CCE/2015.zip', name: 'CC-2015'},
        {src: '/CCE/2015.zip', name: 'CC-2016'},
        {src: '/CCE/2015.zip', name: 'CC-2017'},
        {src: '/CCE/2015.zip', name: 'CC-2018'},
      ]
    },

  ];
  columns = [
    {prop: 'name', name: 'Nombre', class: 'font-weight-bold'},
    {prop: 'description', name: 'Descripción'},
    {prop: 'period', name: 'Período'},
    {prop: 'source', name: 'Fuente', type: 'link'}
  ];

}
