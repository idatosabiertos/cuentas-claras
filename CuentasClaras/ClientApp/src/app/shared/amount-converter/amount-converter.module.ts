import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AmountConverterPipe } from './amount-converter.pipe';

@NgModule({
  declarations: [AmountConverterPipe],
  exports: [AmountConverterPipe],
  imports: [
    CommonModule
  ]
})
export class AmountConverterModule {
}
