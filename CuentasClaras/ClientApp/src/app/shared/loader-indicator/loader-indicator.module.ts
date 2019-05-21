import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderIndicatorDirective } from './loader-indicator.directive';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [LoaderIndicatorDirective],
  exports: [LoaderIndicatorDirective]
})
export class LoaderIndicatorModule {
}
