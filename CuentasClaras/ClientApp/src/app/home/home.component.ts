import { Component, OnDestroy, OnInit } from '@angular/core';
import { HomeStatsService } from './home-stats.service';
import { Subscription } from 'rxjs/index';
import { CurrencyPipe } from '@angular/common';
import { Select, Store } from '@ngxs/store';
import { SetTopBuyersAction, SetTopItemsAction, SetTopSuppliersAction } from './home-state/actions';
import { HomeState } from './home-state/home.state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [CurrencyPipe],
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
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

  private getTopBuyers() {
    const buyersSub = this.topBuyers$.subscribe((topBuyers) => {
      if (!topBuyers) {
        const topBuyersSub = this.homeStats.getTopBuyers().subscribe((data) => {
          this.store.dispatch([new SetTopBuyersAction(data)]);
        });
        this.subs.add(topBuyersSub);
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

  private getTopSuppliers() {
    const suppliersSub = this.topSuppliers$.subscribe((topSuppliers) => {
      if (!topSuppliers) {
        const topSuppliersSub = this.homeStats.getTopSuppliers().subscribe((data) => {
          this.store.dispatch([new SetTopSuppliersAction(data)]);
        });
        this.subs.add(topSuppliersSub);

      } else {
        this.topSuppliers = topSuppliers;
        this.topSuppliersLoading = false;
      }
    }, () => {
      this.topBuyersLoading = false;
    });
    this.subs.add(suppliersSub);
  }

  private getTopItems() {
    const itemsSub = this.topItems$.subscribe((topItems) => {
      if (!topItems) {
        const topItemsSub = this.homeStats.getTopItems().subscribe((data) => {
          this.store.dispatch([new SetTopItemsAction(data)]);
        });
        this.subs.add(topItemsSub);

      } else {
        this.topItems = topItems;
        this.topItemsLoading = false;
      }
    }, () => {
      this.topItemsLoading = false;
    });
    this.subs.add(itemsSub);
  }
}
