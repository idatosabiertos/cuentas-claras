import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {VisualizationsComponent} from './visualizations.component';

const routes: Routes = [
  {path: '', component: VisualizationsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VisualizationsRoutingModule {
}
