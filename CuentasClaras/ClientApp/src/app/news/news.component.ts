import { Component, OnDestroy, OnInit } from '@angular/core';
import { NewsService } from './news.service';
import { Subscription } from 'rxjs/index';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit, OnDestroy {
  public subs = new Subscription();
  public news = [];


  constructor(private newsService: NewsService) {
  }

  public ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public ngOnInit() {
    this.subs.add(this.newsService.getNews()
      .subscribe((data: any) => {
        this.news = data && data.items ? data.items : [];
      }));
  }

}
