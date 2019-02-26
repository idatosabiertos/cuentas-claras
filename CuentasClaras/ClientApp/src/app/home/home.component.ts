import { Component, OnDestroy, OnInit } from '@angular/core';
import { HomeStatsService } from './home-stats.service';
import { Subscription } from 'rxjs/index';
import { CurrencyPipe } from '@angular/common';
import { Select, Store } from '@ngxs/store';
import { SetTopBuyersAction, SetTopSuppliersAction } from './home-state/actions';
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
  subs = new Subscription();
  topBuyers;
  topBuyersLoading = true;
  topSuppliers;
  topSuppliersLoading = true;
  graph = [{
    x: -739.36383, y: -404.26147, id: 'jquery', name: 'jquery',
    symbolSize: 40.7252817, itemStyle: {normal: {color: '#4f19c7'}}
  },
    {
      x: -134.2215, y: -862.7517, id: 'backbone', name: 'backbone',
      symbolSize: 60.1554675, itemStyle: {normal: {color: '#c71969'}}
    },
    {
      x: -818.97516, y: 624.50604, id: 'angular', name: 'angular',
      symbolSize: 60.7816025, itemStyle: {normal: {color: '#c71969'}}
    },
    {
      x: -710.59204, y: 120.37976, id: 'socket.io', name: 'socket.io',
      symbolSize: 19.818306, itemStyle: {normal: {color: '#c71919'}}
    },
    {
      x: -127.03764, y: 477.03778, id: 'underscore', name: 'underscore',
      symbolSize: 40.0429485, itemStyle: {normal: {color: '#c76919'}}
    },
    {
      x: -338.03128, y: -404.62427, id: 'vue.js', name: 'vue.js',
      symbolSize: 80.163814, itemStyle: {normal: {color: '#8419c7'}}
    },
    {
      x: 118.30771, y: -380.16626, id: 'lodash', name: 'lodash',
      symbolSize: 18.935852, itemStyle: {normal: {color: '#c76919'}}
    },
    {
      x: 381.10724, y: -531.28235, id: 'dateformat', name: 'dateformat',
      symbolSize: 30.3863845, itemStyle: {normal: {color: '#c71969'}}
    },
    {
      x: -644.2716, y: -230.14833, id: 'express', name: 'express',
      symbolSize: 49.608772, itemStyle: {normal: {color: '#c71919'}}
    }];

  edges = [{source: 'jquery', target: 'backbone'},
    {source: 'jquery', target: 'vue.js'},
    {source: 'jquery', target: 'lodash'},
    {source: 'jquery', target: 'dateformat'},
    {source: 'backbone', target: 'underscore'},
    {source: 'faye', target: 'cookiejar'},
    {source: 'socket.io', target: 'express'},
    {source: 'socket.io', target: 'faye'},
    {source: 'vue.js', target: 'underscore'},
    {source: 'vue.js', target: 'dateformat'},
    {source: 'express', target: 'socket.io'},
    {source: 'express', target: 'dateformat'}];

  /// TABLES
  topProducts = [
    {name: 'sillas', totalAmount: 40000, quantity: 350000},
    {name: 'papeleria', totalAmount: 30240, quantity: 23300},
    {name: 'lapiceras', totalAmount: 20234, quantity: 102200},
    {name: 'queso', totalAmount: 19234, quantity: 100000},
    {name: 'impresoras', totalAmount: 10234, quantity: 100000},
    {name: 'escritorio', totalAmount: 10234, quantity: 100000},
    {name: 'mesas', totalAmount: 10234, quantity: 100000},
    {name: 'vasos', totalAmount: 10234, quantity: 100000},
    {name: 'toallas', totalAmount: 10234, quantity: 100000},
    {name: 'televisores', totalAmount: 10234, quantity: 100000},
    {name: 'computadoras', totalAmount: 10234, quantity: 100000},
  ];
  topProductsColumn = [
    {prop: 'name', name: 'Producto'},
    {prop: 'totalAmount', name: 'Monto', pipe: this.currencyPipe},
    {prop: 'quantity', name: 'Cantidad'},
  ];

  topSuppliersColumns = [
    {prop: 'name', name: 'Empresa'},
    {prop: 'totalAmount', name: 'Monto', pipe: this.currencyPipe},
    {prop: 'quantity', name: 'Cantidad'},
  ];

  topBuyersColumns = [
    {prop: 'name', name: 'Organismo', minWidth: 250},
    {prop: 'totalAmount', name: 'Monto', pipe: this.currencyPipe},
    {prop: 'quantity', name: 'Cantidad'},
  ];

  constructor(private store: Store,
              private homeStats: HomeStatsService,
              private currencyPipe: CurrencyPipe) {

  }

  public ngOnInit() {
    this.getTopBuyers();
    this.getTopSuppliers();
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
}
