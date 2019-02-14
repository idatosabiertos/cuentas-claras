import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxChartsModule } from '@swimlane/ngx-charts';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
    NgxChartsModule,
  ]
})
export class HomeModule { }
