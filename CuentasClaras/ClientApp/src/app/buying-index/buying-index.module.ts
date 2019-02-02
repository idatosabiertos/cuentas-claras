import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import { BuyingIndexRoutingModule } from './buying-index-routing.module';
import { BuyingIndexComponent } from './buying-index.component';
import { StarRatingModule } from 'angular-star-rating';
import { BuyingIndexItemComponent } from './buying-index-item/buying-index-item.component';

@NgModule({
  declarations: [BuyingIndexComponent, BuyingIndexItemComponent],
  imports: [
    CommonModule,
    BuyingIndexRoutingModule,
    MDBBootstrapModule,
    StarRatingModule.forRoot()
  ]
})
export class BuyingIndexModule { }
