import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BuyingIndexComponent} from './buying-index.component';

const routes: Routes = [
  {path: '', component: BuyingIndexComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuyingIndexRoutingModule {
}
