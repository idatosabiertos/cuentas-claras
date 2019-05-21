import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuyingIndexRoutingModule } from './buying-index-routing.module';
import { BuyingIndexComponent } from './buying-index.component';
import { StarRatingModule } from 'angular-star-rating';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { BuyingIndexStatsService } from './buying-index-stats.service';
import { NgxsModule } from '@ngxs/store';
import { BuyingIndexState } from './buying-index-state/buying-index.state';
import { YearFilterModule } from '../shared/year-filter/year-filter.module';

@NgModule({
  declarations: [BuyingIndexComponent],
  providers: [BuyingIndexStatsService],
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
