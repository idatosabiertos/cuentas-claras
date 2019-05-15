import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YearFilterComponent } from './year-filter/year-filter.component';

@NgModule({
  exports:[YearFilterComponent],
  declarations: [YearFilterComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
