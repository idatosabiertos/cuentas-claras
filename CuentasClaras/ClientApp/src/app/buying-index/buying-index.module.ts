import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuyingIndexRoutingModule } from './buying-index-routing.module';
import { BuyingIndexComponent } from './buying-index.component';
import { StarRatingModule } from 'angular-star-rating';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
  declarations: [BuyingIndexComponent],
  imports: [
    CommonModule,
    BuyingIndexRoutingModule,
    MDBBootstrapModule,
    StarRatingModule.forRoot()
  ]
})
export class BuyingIndexModule {
}
