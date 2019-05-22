import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SafePipe } from './safe.pipe';
import { HomeStatsService } from './home-stats.service';
import { NgxsModule } from '@ngxs/store';
import { HomeState } from './home-state/home.state';
import { YearFilterModule } from '../shared/year-filter/year-filter.module';
import { LoaderIndicatorModule } from '../shared/loader-indicator/loader-indicator.module';

@NgModule({
  declarations: [HomeComponent, SafePipe],
  providers: [HomeStatsService],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    LoaderIndicatorModule,
    NgxDatatableModule,
    NgxChartsModule,
    NgxsModule.forFeature([HomeState]),
    YearFilterModule
  ]
})
export class HomeModule {
}
