import { Component, OnDestroy, OnInit } from '@angular/core';
import { HomeStatsService } from './home-stats.service';
import { Subscription } from 'rxjs/index';
import { Select, Store } from '@ngxs/store';
import {
  SetNetworkSelectedYearAction,
  SetReleaseTypesAction,
  SetReleaseTypesFilterAction,
  SetReleaseTypesSelectedYearAction,
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
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  @Select(HomeState.topBuyersSelectedYear) public topBuyersSelectedYear$;
  @Select(HomeState.topSuppliersSelectedYear) public topSuppliersSelectedYear$;
  @Select(HomeState.topItemsSelectedYear) public topItemsSelectedYear$;
  @Select(HomeState.networkSelectedYear) public networkSelectedYear$;
  @Select(HomeState.releaseTypesSelectedYear) public releaseTypesSelectedYear$;
  @Select(HomeState.releaseTypesFilter) public releaseTypesFilter$;
  @Select(HomeState.topBuyers) private topBuyers$;
  @Select(HomeState.topSuppliers) private topSuppliers$;
  @Select(HomeState.topItems) private topItems$;
  @Select(HomeState.releaseTypes) private releaseTypes$;
  itemsListDDconfig = {
    displayKey: 'description', //if objects array passed which key to be displayed defaults to description
    search: true,//true/false for the search functionlity defaults to false,
    limitTo: 10,
    height: 'auto', //height of the list so that if there are more no of items it can show a scroll defaults to auto. With auto height scroll will never appear
    placeholder: 'Buscar un artículo', // text to be displayed when no item is selected defaults to Select,
    moreText: 'more', // text to be displayed whenmore than one items are selected like Option 1 + 5 more
    noResultsFound: 'No se encontraron resultados', // text to be displayed when no items are found while searching
    searchPlaceholder: 'Buscar', // label thats displayed in search input,
    searchOnKey: 'description' // key on which search should be performed this will be selective search. if undefined this will be extensive search on all keys
  };
  itemsList: any = [];
  selectedItem;
  itemsBusy: Subscription;
  itemsListDisabled = true;

  subs = new Subscription();
  topBuyers;
  topBuyersLoading = true;
  topSuppliers;
  releaseTypes;
  topSuppliersLoading = true;
  topItems;
  topItemsLoading = true;
  years = ['2015', '2016', '2017', '2018'];

  /// items graph data
  itemPriceGraphData: any[];
  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  constructor(private store: Store,
              private homeStats: HomeStatsService) {

  }

  public ngOnInit() {
    this.getListOfItems();
    this.getTopBuyers();
    this.getReleaseTypes();
    this.getTopSuppliers();
    this.getTopItems();
  }

  public ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public onItemChange() {
    const itemsPricesSub = this.homeStats.getItemPrices(this.selectedItem.releaseItemClassificationId).subscribe((prices: any) => {
      const series = [];
      for (const year in prices.releaseItems) {
        let total = 0;
        const units = prices.releaseItems[year];
        for (const unityOfMeassure in units) {
          const items = units[unityOfMeassure];
          for (const item of items) {
            total += item.totalAmountUYU;
          }

        }
        const serie = {name: year, value: total};
        series.push(serie);
      }
      this.itemPriceGraphData = series;
    });
    this.itemsBusy = itemsPricesSub;
    this.subs.add(itemsPricesSub);
  }

  public topBuyersSelectedYear(year) {
    this.topBuyersLoading = true;
    this.subs.add(this.store.dispatch([new SetTopBuyersSelectedYearAction(year)]).subscribe(() => this.requestBuyers()));
  }

  public topItemsSelectedYear(year) {
    this.topItemsLoading = true;
    this.subs.add(this.store.dispatch([new SetTopItemsSelectedYearAction(year)]).subscribe(() => this.requestItems()));
  }

  public topSuppliersSelectedYear(year) {
    this.topSuppliersLoading = true;
    this.subs.add(this.store.dispatch([new SetTopSuppliersSelectedYearAction(year)]).subscribe(() => this.requestSuppliers()));
  }

  public networkSelectedYear(year) {
    this.store.dispatch([new SetNetworkSelectedYearAction(year)]);
  }

  public releaseTypesSelectedYear(year) {
    this.store.dispatch([new SetReleaseTypesSelectedYearAction(year)]);
  }

  public releasesSetActiveFilter(filter) {
    this.store.dispatch([new SetReleaseTypesFilterAction(filter)]);
  }

  public get getReleaseTypeYears() {
    if (this.releaseTypes) {
      return Object.keys(this.releaseTypes);
    }
  }

  public get networkURL() {
    const year = this.store.selectSnapshot(HomeState.networkSelectedYear);
    return `https://cuentasclaras-uy.azurewebsites.net/NetworkApp/index.html#${year}-network.gexf`
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

  private getListOfItems() {
    const itemsListSub = this.homeStats.getListofItems().subscribe((list: any) => {
      this.itemsList = list;
      if (list && list.length > 0) {
        this.itemsListDisabled = false;
        this.selectedItem = list.find((item) => item.releaseItemClassificationId === 9861);
        this.onItemChange();
      }
    });
    this.subs.add(itemsListSub);
    this.itemsBusy = itemsListSub;
  }

  private getReleaseTypes() {
    const releaseTypesSub = this.releaseTypes$.subscribe((releaseTypes) => {
      if (!releaseTypes) {
        this.requestReleaseTypes();
      } else {
        this.releaseTypes = releaseTypes;
      }
    });
    this.subs.add(releaseTypesSub);
  }

  private requestReleaseTypes() {
    const releaseTypesSub = this.homeStats.getReleaseTypes().subscribe((releaseTypes) => {
      const result = {};
      const years = Object.keys(releaseTypes);
      for (const year of years) {
        result[year] = {};
        result[year].amount = this.generateSeries(releaseTypes[year].releasesTypesByTotalAmountUYU);
        result[year].qty = this.generateSeries(releaseTypes[year].releasesTypesByQuantity);
      }
      this.store.dispatch(new SetReleaseTypesAction(result));
    });
    this.subs.add(releaseTypesSub);
  }

  generateSeries(item) {
    let series = [];
    const keys = Object.keys(item);
    for (const key of keys) {
      series.push({name: key, value: item[key]});
    }
    return series;
  }
}
