import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/index';
import { BuyingIndexStatsService } from './buying-index-stats.service';
import { Select, Store } from '@ngxs/store';
import { BuyingIndexState } from './buying-index-state/buying-index.state';
import { SetBuyingIndexDataAction, SetBuyingIndexSelectedYearAction } from './buying-index-state/actions';

@Component({
  selector: 'app-buying-index',
  templateUrl: './buying-index.component.html',
  styleUrls: ['./buying-index.component.scss']
})
export class BuyingIndexComponent implements OnInit, OnDestroy {
  @Select(BuyingIndexState.selectedYear) selectedYear$;
  @Select(BuyingIndexState.indexData) indexData$;
  years = ['2015', '2016', '2017', '2018'];
  subs = new Subscription();
  indexData: any;
  indexDataLoading = true;


  constructor(private indexStatsService: BuyingIndexStatsService, private store: Store) {
  }

  public ngOnInit() {
    this.getIndexData();
  }

  public ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public indexSelectedYear(year) {
    this.indexDataLoading = true;
    this.subs.add(this.store.dispatch(new SetBuyingIndexSelectedYearAction(year)).subscribe(() => this.requestIndexData()));
  }

  private requestIndexData() {
    const selectedYear = this.store.selectSnapshot(BuyingIndexState.selectedYear);
    const indexSub = this.indexStatsService.getIndex(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch(new SetBuyingIndexDataAction(data)).subscribe(() => {
          this.indexDataLoading = false;
        }
      ));
    });
    this.subs.add(indexSub);
  }

  private getIndexData() {
    const itemsSub = this.indexData$.subscribe((data) => {
      if (!data) {
        this.requestIndexData();
      } else {
        this.indexData = data;
        this.indexDataLoading = false;
      }
    }, () => {
      this.indexDataLoading = false;
    });
    this.subs.add(itemsSub);
  }

}
