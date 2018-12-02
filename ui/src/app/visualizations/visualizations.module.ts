import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VisualizationsRoutingModule } from './visualizations-routing.module';
import { VisualizationsComponent } from './visualizations.component';

@NgModule({
  declarations: [VisualizationsComponent],
  imports: [
    CommonModule,
    VisualizationsRoutingModule
  ]
})
export class VisualizationsModule { }
