import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import {FooterComponent} from './layout/footer/footer.component';
import {HeaderComponent} from './layout/header/header.component';
import {RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { NgxsStoragePluginModule } from '@ngxs/storage-plugin';
import { HomeState } from '../home/home-state/home.state';

@NgModule({
  declarations: [FooterComponent, HeaderComponent],
  exports: [FooterComponent, HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    NgxsModule.forRoot([HomeState]),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsLoggerPluginModule.forRoot({disabled: environment.production}),
    NgxsStoragePluginModule.forRoot(),
  ]
})
export class CoreModule {
}
