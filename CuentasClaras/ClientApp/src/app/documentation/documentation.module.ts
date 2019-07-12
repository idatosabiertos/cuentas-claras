import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {  DocumentationComponent } from './documentation.component';
import { DocumentationRoutingModule } from './documentation-routing.module';

@NgModule({
  declarations: [DocumentationComponent],
  imports: [
    CommonModule,
    DocumentationRoutingModule,
    MDBBootstrapModule
  ]
})
export class DocumentationModule {
}
