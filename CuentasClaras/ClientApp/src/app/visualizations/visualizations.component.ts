import { Component, OnDestroy, OnInit } from '@angular/core';
import { Chart } from 'angular-highcharts';
import { VisualizationsStatsService } from './visualizations-stats.service';
import { Subscription } from 'rxjs/index';

@Component({
  selector: 'app-visualizations',
  templateUrl: './visualizations.component.html',
  styleUrls: ['./visualizations.component.scss']
})
export class VisualizationsComponent implements OnInit, OnDestroy {
  selectedOrgId;
  busy: Subscription;
  range = [2015, 2018];
  subs = new Subscription();

  //Graph Data

  organisms = [{id: 1, name: 'org1'}, {id: 2, name: 'org2'}];

  // pie chart
  releaseTypes = [];
  releasesQty = 0;
  releasesAmount = 0;

  //Tree map
  productsTypes = [];
  suppliers = [];

  boxChartData = [];
  boxChartOptions: any = {

    chart: {
      type: 'boxplot'
    },

    title: {
      text: 'Los 10 artículos más comprados'
    },

    legend: {
      enabled: false
    },

    xAxis: {
      categories: ['1', '2', '3', '4', '5'],
      title: {
        text: 'Artículo'
      }
    },

    yAxis: {
      title: {
        text: 'Precio'
      },
      plotLines: [{
        value: 932,
        color: 'red',
        width: 1,
        label: {
          text: 'Mediana teórica: 932',
          align: 'center',
          style: {
            color: 'gray'
          }
        }
      }]
    },

    series: this.boxChartData
  };
  boxChart = new Chart(this.boxChartOptions);

  radarData = [];
  radarLabels = [
    'Acumulación de proveedores por organismo',
    'Completitud de información',
    'Concentración de proveedores',
    'Conexiones según monto',
    'Descripción',
    'Desempeño',
    'Tipo de procedimiento',
    'Cantidad de compras por excepción',
    'Empresa sancionada'
  ];

  constructor(private visualizationStats: VisualizationsStatsService) {
  }

  ngOnInit() {
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

  onOrgChange(id) {
    this.selectedOrgId = id;
    this.getData();
  }

  onSliderChange() {
      this.getData();
  }

  getData() {
    if(this.range && this.selectedOrgId !==undefined){
      this.clearData();
      const statsSub = this.visualizationStats.getStats(this.range, this.selectedOrgId).subscribe((data: any) => {
        this.releasesQty = data.releasesQuantity;
        this.releasesAmount = data.totalAmountUYU;
        this.releaseTypes = this.generateSeries(data.releasesTypes);
        this.productsTypes = this.generateSeries(data.productsTypesTotalAmountUYU);
        this.suppliers = this.generateSeries(data.suppliersTotalAmountUYU);
        this.radarData = this.generateRadarData(data.organisationIndexes);
        this.boxChartData = [{
          name: 'Precios',
          data: [
            [760, 801, 848, 895, 965],
            [733, 853, 939, 980, 1080],
            [714, 762, 817, 870, 918],
            [724, 802, 806, 871, 950],
            [834, 836, 864, 882, 910]
          ],
          tooltip: {
            headerFormat: '<em>{point.key}</em><br/>'
          }
        }];
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
          this.getPercentage(dataset.accumulationOfSuppliersByOrganisation),
          this.getPercentage(dataset.completedInfo),
          this.getPercentage(dataset.concentrationOfSuppliers),
          this.getPercentage(dataset.conectionByAmount),
          this.getPercentage(dataset.description),
          this.getPercentage(dataset.performanceIndex),
          this.getPercentage(dataset.process),
          this.getPercentage(dataset.quantityOfPurchasesByException),
          this.getPercentage(dataset.sanctionedCompanies)
        ],
        label: dataset.year
      })

    }
    return data;
  }

  getPercentage(num) {
    const parsedNum = parseFloat(num);
    return isNaN(parsedNum) ? 0 : parsedNum * 100;
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
    return this.boxChartData && this.boxChartData.length > 0;
  }

  clearData() {
    this.releaseTypes = [];
    this.releasesQty = 0;
    this.releasesAmount = 0;
    this.productsTypes = [];
    this.suppliers = [];
    this.radarData = [];
    this.boxChartData = [];
  }
}
