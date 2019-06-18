import { Component, NgZone, OnDestroy, OnInit } from '@angular/core';
import { Chart } from 'angular-highcharts';
import { VisualizationsStatsService } from './visualizations-stats.service';
import { Subscription } from 'rxjs/index';

@Component({
  selector: 'app-visualizations',
  templateUrl: './visualizations.component.html',
  styleUrls: ['./visualizations.component.scss']
})
export class VisualizationsComponent implements OnInit, OnDestroy {
  orgsDisabled = true;
  selectedOrg;
  showNotFound = false;
  busy: Subscription;
  range = [2015, 2018];
  subs = new Subscription();

  //Graph Data

  organisms: any[] = [];

  // pie chart
  releaseTypes = [];
  releasesQty = 0;
  releasesAmount = 0;

  //Tree map
  productsActiveTab = 'amount';
  productsTypes = [];
  productsTypesQuantity = [];

  suppliers = [];

  boxChartOptions: any = {
    chart: {
      type: 'boxplot'
    },
    title: {
      text: ''
    },
    legend: {
      enabled: false
    },
    xAxis: {
      title: {
        text: 'Artículo'
      }
    },
    yAxis: {
      title: {
        text: 'Precio (sin IVA)'
      }
    }
  };
  boxChart = new Chart(this.boxChartOptions);

  radarData = [];
  radarLabels = [
    'Acumulación de proveedores por organismo',
    'Completitud de información',
    'Concentración de proveedores',
    'Conexiones según monto',
    'Descripción',
    'Tipo de procedimiento',
    'Cantidad de compras por excepción',
    'Empresa sancionada'
  ];

  constructor(private visualizationStats: VisualizationsStatsService,
              private zone: NgZone) {
  }

  ngOnInit() {
    this.subs.add(this.visualizationStats.getBuyersList().subscribe((buyers: any) => {
      this.organisms = buyers;
      this.orgsDisabled = false;
      this.selectedOrg = buyers[0];
      this.onOrgChange();
    }));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public keyboard2: number[] = [1, 3];
  private keyboardEventHandler = (e: KeyboardEvent) => {
    // determine which handle triggered the event
    let index = parseInt((<HTMLElement>e.target).getAttribute('data-handle'));

    let multiplier: number = 0;
    let stepSize = 0.1;

    switch (e.which) {
      case 40:  // ArrowDown
      case 37:  // ArrowLeft
        multiplier = -2;
        e.preventDefault();
        break;

      case 38:  // ArrowUp
      case 39:  // ArrowRight
        multiplier = 3;
        e.preventDefault();
        break;

      default:
        break;
    }

    let delta = multiplier * stepSize;
    let newValue = [].concat(this.keyboard2);
    newValue[index] += delta;
    this.keyboard2 = newValue;
  };
  public someKeyboardConfig2: any = {
    keyboard: true,
    onKeydown: this.keyboardEventHandler
  };

  onOrgChange() {
    this.getData();
  }

  onSliderChange() {
    this.getData();
  }

  getData() {
    this.showNotFound = false;
    if (this.range && this.selectedOrg !== undefined) {
      this.clearData();
      const statsSub = this.visualizationStats.getStats(this.range, this.selectedOrg.buyerId).subscribe((data: any) => {
        this.releasesQty = data.releasesQuantity;
        this.releasesAmount = data.totalAmountUYU;
        this.releaseTypes = this.generateSeries(data.releasesTypes);
        this.productsTypes = this.generateSeries(data.productsTypesTotalAmountUYU);
        this.productsTypesQuantity = this.generateSeries(data.productsTypesQuantity);
        this.suppliers = this.generateSeries(data.suppliersTotalAmountUYU);
        this.radarData = this.generateRadarData(data.organisationIndexes);
        this.generateBoxChartData(data.topProductsByTotalAmountUYU);
        this.showNotFound = true;
      }, () => {
        this.showNotFound = false;
      });
      this.busy = statsSub;
      this.subs.add(statsSub);
    }
  }

  generateSeries(item) {
    let series = [];
    const keys = Object.keys(item);
    for (const key of keys) {
      series.push({name: key, value: item[key]});
    }
    return series;
  }

  generateRadarData(items) {
    let data = [
      // {data: [65, 59, 80, 81, 56, 55, 40], label: 'My First dataset'}
    ];
    for (const dataset of items) {
      data.push({
        data: [
          this.parseNum(dataset.accumulationOfSuppliersByOrganisation),
          this.parseNum(dataset.completedInfo),
          this.parseNum(dataset.concentrationOfSuppliers),
          this.parseNum(dataset.conectionByAmount),
          this.parseNum(dataset.description),
          this.parseNum(dataset.process),
          this.parseNum(dataset.quantityOfPurchasesByException),
          this.parseNum(dataset.sanctionedCompanies)
        ],
        label: dataset.year
      })

    }
    return data;
  }

  generateBoxChartData(items) {
    let series = [];
    let labels = [];
    for (const item of items) {
      series.push([item.min, item.q1, item.mean, item.q3, item.max]);
      labels.push(item.description);
    }
    // update the chart with the new info
    this.zone.run(() => {
      this.boxChartOptions.series = [{
        name: 'Precios (sin IVA)',
        data: series,
        tooltip: {
          headerFormat: '',
          pointFormatter: function() {
            const x = this.x;
            const currentData = this.series.data.find(data => data.x === x);
            const boxplotValues = currentData ? currentData.options : {};
            return `Máximo: $${boxplotValues.high}<br>
              Q3: $${boxplotValues.q3}<br>
              Mediana: $${boxplotValues.median}<br>
              Q1: $${boxplotValues.q1}<br>
              Mínimo: $${boxplotValues.low}<br>`;
          }
        }
      }];
      this.boxChartOptions.xAxis.categories = labels;
      this.boxChart = new Chart(this.boxChartOptions);
    });

  }

  parseNum(num) {
    const parsedNum = parseFloat(num);
    return isNaN(parsedNum) ? 0 : parsedNum;
  }

  get showPieChart() {
    return this.releaseTypes && this.releaseTypes.length > 0;
  }

  get showGeneralData() {
    return this.releasesQty > 0 && this.releasesAmount > 0;
  }

  get showProductsTypes() {
    return this.productsTypes && this.productsTypes.length > 0;
  }

  get showSuppliers() {
    return this.suppliers && this.suppliers.length > 0;
  }

  get showRadarData() {
    return this.radarData && this.radarData.length > 0;
  }

  get showBoxChart() {
    return this.boxChartOptions.series && this.boxChartOptions.series.length > 0;
  }

  clearData() {
    this.releaseTypes = [];
    this.releasesQty = 0;
    this.releasesAmount = 0;
    this.productsTypes = [];
    this.suppliers = [];
    this.radarData = [];
    this.boxChartOptions.series = [];
    this.boxChartOptions.xAxis.categories = [];
  }
}
