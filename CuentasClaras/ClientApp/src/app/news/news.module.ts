import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NewsRoutingModule } from './news-routing.module';
import { NewsComponent } from './news.component';
import { PostComponent } from './post/post.component';
import { NewsService } from './news.service';

@NgModule({
  declarations: [NewsComponent, PostComponent],
  providers: [NewsService],
  imports: [
    CommonModule,
    NewsRoutingModule,
    MDBBootstrapModule
  ]
})
export class NewsModule {
}
