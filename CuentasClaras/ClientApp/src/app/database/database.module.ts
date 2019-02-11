import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { DatabaseRoutingModule } from './database-routing.module';
import { DatabaseComponent } from './database.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [DatabaseComponent],
  imports: [
    CommonModule,
    DatabaseRoutingModule,
    NgxDatatableModule,
    MDBBootstrapModule
  ]
})
export class DatabaseModule {
}
