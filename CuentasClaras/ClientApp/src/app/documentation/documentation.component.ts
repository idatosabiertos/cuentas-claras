import { Component } from '@angular/core';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.scss']
})
export class DocumentationComponent {
  rows = [
    {
      name: 'Metodología del Índice de Desempeño de las Contrataciones Públicas',
      description: 'Este documento detalla el proceso metodológico de construcción del Índice de Desempeño en las Contrataciones Públicas.',
      file: '/documentation/Informe - Metodologia.pdf'

    },
    {
      name: 'Documentación del Trabajo de Cuentas Claras',
      description: 'Este documento detalla el proceso de trabajo a partir de las fuentes de datos utilizadas en el análisis de este sitio web y recomendaciones para los organismos públicos implicados.',
      file: '/documentation/Informe - Compras y contrataciones públicas en Uruguay.pdf'
    },

  ];
  columns = [
    {prop: 'name', name: 'Nombre', class: 'font-weight-bold'},
    {prop: 'description', name: 'Descripción'},
  ];

}
