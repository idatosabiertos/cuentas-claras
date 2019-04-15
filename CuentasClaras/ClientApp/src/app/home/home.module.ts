import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { YearFilterComponent } from './year-filter/year-filter.component';

@NgModule({
  declarations: [HomeComponent, YearFilterComponent],
  providers: [],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
  ]
})
export class HomeModule {
}
