import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import {MDBBootstrapModule} from "angular-bootstrap-md";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [ContactComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ContactRoutingModule,
    MDBBootstrapModule,
    HttpClientModule
  ]
})
export class ContactModule { }
