import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { DatabaseRoutingModule } from './database-routing.module';
import { DatabaseComponent } from './database.component';

@NgModule({
  declarations: [DatabaseComponent],
  imports: [
    CommonModule,
    DatabaseRoutingModule,
    MDBBootstrapModule
  ]
})
export class DatabaseModule {
}
