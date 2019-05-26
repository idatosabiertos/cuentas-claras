import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YearFilterComponent } from './year-filter.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
  exports:[YearFilterComponent],
  declarations: [YearFilterComponent],
  imports: [
    CommonModule,
    MDBBootstrapModule
  ]
})
export class YearFilterModule { }
