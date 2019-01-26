import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import {FooterComponent} from './layout/footer/footer.component';
import {HeaderComponent} from './layout/header/header.component';
import {RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [FooterComponent, HeaderComponent],
  exports: [FooterComponent, HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
  ]
})
export class CoreModule {
}
