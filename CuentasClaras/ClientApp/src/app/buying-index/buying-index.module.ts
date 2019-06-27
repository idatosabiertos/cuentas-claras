import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuyingIndexRoutingModule } from './buying-index-routing.module';
import { BuyingIndexComponent } from './buying-index.component';
import { StarRatingConfigService, StarRatingModule } from 'angular-star-rating';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { BuyingIndexStatsService } from './buying-index-stats.service';
import { NgxsModule } from '@ngxs/store';
import { BuyingIndexState } from './buying-index-state/buying-index.state';
import { YearFilterModule } from '../shared/year-filter/year-filter.module';
import { CustomStarRatingConfigService } from './custom-star-rating-config.service';

@NgModule({
  declarations: [BuyingIndexComponent],
  providers: [
    BuyingIndexStatsService,
    {provide: StarRatingConfigService, useClass: CustomStarRatingConfigService}
  ],
  imports: [
    CommonModule,
    BuyingIndexRoutingModule,
    MDBBootstrapModule,
    NgxDatatableModule,
    YearFilterModule,
    NgxsModule.forFeature([BuyingIndexState]),
    StarRatingModule.forRoot()
  ]
})
export class BuyingIndexModule {
}
