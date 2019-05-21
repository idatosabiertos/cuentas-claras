import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NouisliderComponent } from 'ng2-nouislider';
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
  @ViewChild('someKeyboardSlider2') someKeyboardSlider2: NouisliderComponent;

  //Graph Data

  organisms = [{id: 1, name: 'org1'}, {id: 2, name: 'org2'}];

  // pie chart
  releaseTypes = [];
  releasesQty = 0;
  releasesAmount = 0;

  //Tree map
  productsTypes = [];
  suppliers = [];

  boxChartOptions: any = {

    chart: {
      type: 'boxplot'
    },

    title: {
      text: 'Highcharts Box Plot Example'
    },

    legend: {
      enabled: false
    },

    xAxis: {
      categories: ['1', '2', '3', '4', '5'],
      title: {
        text: 'Experiment No.'
      }
    },

    yAxis: {
      title: {
        text: 'Observations'
      },
      plotLines: [{
        value: 932,
        color: 'red',
        width: 1,
        label: {
          text: 'Theoretical mean: 932',
          align: 'center',
          style: {
            color: 'gray'
          }
        }
      }]
    },

    series: [{
      name: 'Observations',
      data: [
        [760, 801, 848, 895, 965],
        [733, 853, 939, 980, 1080],
        [714, 762, 817, 870, 918],
        [724, 802, 806, 871, 950],
        [834, 836, 864, 882, 910]
      ],
      tooltip: {
        headerFormat: '<em>Experiment No {point.key}</em><br/>'
      }
    }, {
      name: 'Outlier',
      type: 'scatter',
      data: [ // x, y positions where 0 is the first category
        [0, 644],
        [4, 718],
        [4, 951],
        [4, 969]
      ],
      marker: {
        fillColor: 'white',
        lineWidth: 1
      },
      tooltip: {
        pointFormat: 'Observation: {point.y}'
      }
    }]

  };
  boxChart = new Chart(this.boxChartOptions);

  radarData = [];
  radarLabels = [
    'accumulationOfSuppliersByOrganisation',
    'completedInfo',
    'concentrationOfSuppliers',
    'conectionByAmount',
    'description',
    'performanceIndex',
    'Process',
    'quantityOfPurchasesByException',
    'sanctionedCompanies'
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

  getData() {
    this.clearData();
    const statsSub = this.visualizationStats.getStats(this.range, this.selectedOrgId).subscribe((data: any) => {
      this.releasesQty = data.releasesQuantity;
      this.releasesAmount = data.totalAmountUYU;
      this.releaseTypes = this.generateSeries(data.releasesTypes);
      this.productsTypes = this.generateSeries(data.productsTypesTotalAmountUYU);
      this.suppliers = this.generateSeries(data.suppliersTotalAmountUYU);
      this.radarData = this.generateRadarData(data.organisationIndexes);
    });
    this.busy = statsSub;
    this.subs.add(statsSub);
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
          parseFloat(dataset.accumulationOfSuppliersByOrganisation)*100,
          parseFloat(dataset.completedInfo)*100,
          parseFloat(dataset.concentrationOfSuppliers)*100,
          parseFloat(dataset.conectionByAmount)*100,
          parseFloat(dataset.description)*100,
          parseFloat(dataset.performanceIndex)*100,
          parseFloat(dataset.process)*100,
          parseFloat(dataset.quantityOfPurchasesByException)*100,
          parseFloat(dataset.sanctionedCompanies)*100
        ],
        label: dataset.year
      })

    }
    return data;
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
    return this.boxChart ? true : false;
  }

  clearData(){
    this.releaseTypes=[];
    this.releasesQty=0;
    this.releasesAmount=0;
    this.productsTypes=[];
    this.suppliers=[];
    this.radarData=[];
  }
}
