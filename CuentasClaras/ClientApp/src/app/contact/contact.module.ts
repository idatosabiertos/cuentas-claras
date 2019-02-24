import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import {MDBBootstrapModule} from "angular-bootstrap-md";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RECAPTCHA_SETTINGS, RecaptchaModule, RecaptchaSettings } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';

@NgModule({
  declarations: [ContactComponent],
  providers:[{
    provide: RECAPTCHA_SETTINGS,
    useValue: {
      // siteKey: '6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI',
      siteKey: '6LdJ4pIUAAAAAMJDLUesa4qpEJJ20JeFvT5qf3mG',
    } as RecaptchaSettings,
  }],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RecaptchaFormsModule,
    RecaptchaModule,
    ContactRoutingModule,
    MDBBootstrapModule,
    HttpClientModule
  ]
})
export class ContactModule { }
