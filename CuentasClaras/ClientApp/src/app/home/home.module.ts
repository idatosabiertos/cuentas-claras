import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule
  ]
})
export class HomeModule { }
