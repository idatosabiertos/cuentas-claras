import { Component, OnDestroy, OnInit } from '@angular/core';
import { HomeStatsService } from './home-stats.service';
import { Subscription } from 'rxjs/index';
import { CurrencyPipe } from '@angular/common';
import { Select, Store } from '@ngxs/store';
import {
  SetNetworkSelectedYearAction,
  SetTopBuyersAction,
  SetTopBuyersSelectedYearAction,
  SetTopItemsAction,
  SetTopItemsSelectedYearAction,
  SetTopSuppliersAction,
  SetTopSuppliersSelectedYearAction
} from './home-state/actions';
import { HomeState } from './home-state/home.state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [CurrencyPipe],
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  @Select(HomeState.topBuyersSelectedYear) public topBuyersSelectedYear$;
  @Select(HomeState.topBuyersSelectedYear) public topSuppliersSelectedYear$;
  @Select(HomeState.topItemsSelectedYear) public topItemsSelectedYear$;
  @Select(HomeState.networkSelectedYear) public networkSelectedYear$;
  @Select(HomeState.topBuyers) private topBuyers$;
  @Select(HomeState.topBuyers) private topSuppliers$;
  @Select(HomeState.topItems) private topItems$;
  subs = new Subscription();
  topBuyers;
  topBuyersLoading = true;
  topSuppliers;
  topSuppliersLoading = true;
  topItems;
  topItemsLoading = true;
  years = ['2015', '2016', '2017'];

  constructor(private store: Store,
              private homeStats: HomeStatsService) {

  }

  public ngOnInit() {
    this.getTopBuyers();
    this.getTopSuppliers();
    this.getTopItems();
  }

  public ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public topBuyersSelectedYear(year) {
    this.topBuyersLoading = true;
    this.store.dispatch([new SetTopBuyersSelectedYearAction(year)]).subscribe(() => this.requestBuyers());
  }

  public topItemsSelectedYear(year) {
    this.topItemsLoading = true;
    this.store.dispatch([new SetTopItemsSelectedYearAction(year)]).subscribe(() => this.requestItems());
  }

  public topSuppliersSelectedYear(year) {
    this.topSuppliersLoading = true;
    this.store.dispatch([new SetTopSuppliersSelectedYearAction(year)]).subscribe(() => this.requestSuppliers());
  }

  public networkSelectedYear(year) {
    ///replace true with logic to select network
    this.store.dispatch([new SetNetworkSelectedYearAction(year)]).subscribe(() => true);
  }

  private getTopBuyers() {
    const buyersSub = this.topBuyers$.subscribe((topBuyers) => {
      if (!topBuyers) {
        this.requestBuyers();
      }
      else {
        this.topBuyers = topBuyers;
        this.topBuyersLoading = false;
      }
    }, () => {
      this.topBuyersLoading = false;
    });
    this.subs.add(buyersSub);
  }

  private requestBuyers() {
    const selectedYear = this.store.selectSnapshot(HomeState.topBuyersSelectedYear);
    const topBuyersSub = this.homeStats.getTopBuyers(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopBuyersAction(data)]).subscribe(() => {
        this.topBuyersLoading = false;
      }));
    });
    this.subs.add(topBuyersSub);
  }

  private getTopSuppliers() {
    const suppliersSub = this.topSuppliers$.subscribe((topSuppliers) => {
      if (!topSuppliers) {
        this.requestSuppliers();
      } else {
        this.topSuppliers = topSuppliers;
        this.topSuppliersLoading = false;
      }
    }, () => {
      this.topBuyersLoading = false;
    });
    this.subs.add(suppliersSub);
  }

  private requestSuppliers() {
    const selectedYear = this.store.selectSnapshot(HomeState.topSuppliersSelectedYear);
    const topSuppliersSub = this.homeStats.getTopSuppliers(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopSuppliersAction(data)]).subscribe(() => {
        this.topSuppliersLoading = false;
      }));
    });
    this.subs.add(topSuppliersSub);
  }

  private getTopItems() {
    const itemsSub = this.topItems$.subscribe((topItems) => {
      if (!topItems) {
        this.requestItems();
      } else {
        this.topItems = topItems;
        this.topItemsLoading = false;
      }
    }, () => {
      this.topItemsLoading = false;
    });
    this.subs.add(itemsSub);
  }

  private requestItems() {
    const selectedYear = this.store.selectSnapshot(HomeState.topItemsSelectedYear);
    const topItemsSub = this.homeStats.getTopItems(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopItemsAction(data)]).subscribe(() => {
        this.topItemsLoading = false;
      }));
    });
    this.subs.add(topItemsSub);
  }
}
