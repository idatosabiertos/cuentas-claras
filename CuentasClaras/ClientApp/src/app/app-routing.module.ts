import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'home', loadChildren: './home/home.module#HomeModule'},
  {path: 'contact', loadChildren: './contact/contact.module#ContactModule'},
  {path: 'about-project', loadChildren: './about-project/about-project.module#AboutProjectModule'},
  {path: 'buying-index', loadChildren: './buying-index/buying-index.module#BuyingIndexModule'},
  {path: 'news', loadChildren: './news/news.module#NewsModule'},
  {path: 'visualizations', loadChildren: './visualizations/visualizations.module#VisualizationsModule'},
  {path: 'database', loadChildren: './database/database.module#DatabaseModule'},
  {path: 'contact', loadChildren: './contact/contact.module#ContactModule'},
  {path: '**', redirectTo: '/home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
