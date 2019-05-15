import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import { MDBBootstrapModule } from "angular-bootstrap-md";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RECAPTCHA_SETTINGS, RecaptchaModule, RecaptchaSettings } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { ContactService } from './contact.service';

@NgModule({
  declarations: [ContactComponent],
  providers: [
    ContactService,
    {
      provide: RECAPTCHA_SETTINGS,
      useValue: {
        // siteKey: '6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI',
        siteKey: '6LfO_ZgUAAAAAEokoDy-RNkB07zCYDVRnNjy412H',
      } as RecaptchaSettings,
    }
  ],
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
export class ContactModule {
}
