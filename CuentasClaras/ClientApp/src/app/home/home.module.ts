import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SafePipe } from './safe.pipe';
import { SharedModule } from '../shared/shared/shared.module';
import { HomeStatsService } from './home-stats.service';
import { NgxsModule } from '@ngxs/store';
import { HomeState } from './home-state/home.state';

@NgModule({
  declarations: [HomeComponent, SafePipe],
  providers: [HomeStatsService],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
    NgxChartsModule,
    NgxsModule.forFeature([HomeState]),
    SharedModule
  ]
})
export class HomeModule {
}
