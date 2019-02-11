import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
  ]
})
export class HomeModule { }
