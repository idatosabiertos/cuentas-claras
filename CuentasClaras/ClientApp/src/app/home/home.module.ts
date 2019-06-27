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
import { SelectDropDownModule } from 'ngx-select-dropdown';
import { FormsModule } from '@angular/forms';
import { AmountConverterModule } from '../shared/amount-converter/amount-converter.module';
import { AmountConverterPipe } from '../shared/amount-converter/amount-converter.pipe';

@NgModule({
  declarations: [HomeComponent, SafePipe],
  providers: [HomeStatsService, AmountConverterPipe],
  imports: [
    CommonModule,
    AmountConverterModule,
    FormsModule,
    HomeRoutingModule,
    MDBBootstrapModule,
    LoaderIndicatorModule,
    NgxDatatableModule,
    NgxChartsModule,
    SelectDropDownModule,
    NgxsModule.forFeature([HomeState]),
    YearFilterModule
  ]
})
export class HomeModule {
}
