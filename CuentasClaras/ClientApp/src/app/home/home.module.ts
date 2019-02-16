import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CovalentGraphEchartsModule } from '@covalent/echarts/graph';
import { CovalentBaseEchartsModule } from '@covalent/echarts/base';
import { CovalentTooltipEchartsModule } from '@covalent/echarts/tooltip';
import { MatIconModule } from '@angular/material';

@NgModule({
  declarations: [HomeComponent],
  providers: [],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
    CovalentTooltipEchartsModule,
    CovalentGraphEchartsModule,
    CovalentBaseEchartsModule,
    MatIconModule,
  ]
})
export class HomeModule {
}
