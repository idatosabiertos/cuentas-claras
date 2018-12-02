import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AboutProjectRoutingModule } from './about-project-routing.module';
import { AboutProjectComponent } from './about-project.component';

@NgModule({
  declarations: [AboutProjectComponent],
  imports: [
    CommonModule,
    AboutProjectRoutingModule
  ]
})
export class AboutProjectModule { }
