import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuyingIndexRoutingModule } from './buying-index-routing.module';
import { BuyingIndexComponent } from './buying-index.component';

@NgModule({
  declarations: [BuyingIndexComponent],
  imports: [
    CommonModule,
    BuyingIndexRoutingModule
  ]
})
export class BuyingIndexModule { }
