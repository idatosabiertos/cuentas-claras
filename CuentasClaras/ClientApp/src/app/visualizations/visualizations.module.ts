import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VisualizationsRoutingModule } from './visualizations-routing.module';
import { VisualizationsComponent } from './visualizations.component';
import { ChartsModule, MDBBootstrapModule } from 'angular-bootstrap-md';
import { NouisliderModule } from 'ng2-nouislider';
import { FormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ChartModule, HIGHCHARTS_MODULES } from 'angular-highcharts';
import * as more from 'highcharts/highcharts-more.src';
import * as exporting from 'highcharts/modules/exporting.src';
import { VisualizationsStatsService } from './visualizations-stats.service';
import { LoaderIndicatorModule } from '../shared/loader-indicator/loader-indicator.module';
import { SelectDropDownModule } from 'ngx-select-dropdown';
import { AmountConverterModule } from '../shared/amount-converter/amount-converter.module';
import { AmountConverterPipe } from '../shared/amount-converter/amount-converter.pipe';

@NgModule({
  declarations: [VisualizationsComponent],
  imports: [
    CommonModule,
    FormsModule,
    VisualizationsRoutingModule,
    MDBBootstrapModule,
    SelectDropDownModule,
    AmountConverterModule,
    NouisliderModule,
    NgxChartsModule,
    ChartsModule,
    ChartModule,
    LoaderIndicatorModule
  ],
  providers: [
    AmountConverterPipe,
    VisualizationsStatsService,
    {provide: HIGHCHARTS_MODULES, useFactory: () => [more, exporting]} // add as factory to your providers
  ]
})
export class VisualizationsModule {
}
