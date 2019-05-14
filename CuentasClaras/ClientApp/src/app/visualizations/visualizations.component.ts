import { Component, OnInit, ViewChild } from '@angular/core';
import { NouisliderComponent } from 'ng2-nouislider';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-visualizations',
  templateUrl: './visualizations.component.html',
  styleUrls: ['./visualizations.component.scss']
})
export class VisualizationsComponent implements OnInit {

  @ViewChild('someKeyboardSlider2') someKeyboardSlider2: NouisliderComponent;
  range = [2015, 2018];
  organisms = [{id: 1, name: 'org1'}, {id: 2, name: 'org2'}];
  pieChartData = [
    {
      "name": "Compra por Exepcion",
      "value": 8940000
    },
    {
      "name": "Licitacion publica",
      "value": 5000000
    },
    {
      "name": "Compra directa",
      "value": 3000000
    },
    {
      "name": "Procedimiento especial",
      "value": 2000000
    },
    {
      "name": "Pregon",
      "value": 1000000
    }
  ];

  treeMapData = [
    {
      "name": "Germany",
      "value": 90632
    },
    {
      "name": "Italy",
      "value": 15800
    },
    {
      "name": "France",
      "value": 36745
    },
    {
      "name": "United Kingdom",
      "value": 36240
    },
    {
      "name": "United States",
      "value": 49737
    },
    {
      "name": "Spain",
      "value": 23000
    }
  ];
  boxChart = new Chart(
    {

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

    });

  radarData: Array<any> = [
    {data: [65, 59, 80, 81, 56, 55, 40], label: 'My First dataset'},
    {data: [28, 48, 40, 19, 86, 27, 90], label: 'My Second dataset'}
  ];

  constructor() {
  }

  ngOnInit() {
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
  }

  onOrgChange(id) {
    console.log(id);
  }

}
