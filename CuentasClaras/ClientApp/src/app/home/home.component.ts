import { Component, OnInit } from '@angular/core';
import * as shape from 'd3-shape';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {


  /// TABLES
  rows = [
    {name: 'Austin', gender: 'Male', company: 'Swimlane'},
    {name: 'Dany', gender: 'Male', company: 'KFC'},
    {name: 'Molly', gender: 'Female', company: 'Burger King'},
  ];
  columns = [
    {prop: 'name'},
    {name: 'Gender'},
    {name: 'Company'}
  ];


  // NETWORK GRAPH

  hierarchialGraph = {nodes: [], links: []}
  curve = shape.curveBundle.beta(1);

  constructor() {
  }

  public ngOnInit(): void {
    this.showGraph();
  }

  showGraph() {
    this.hierarchialGraph.nodes = [
      {
        id: 'start',
        label: 'scan',
        position: 'x0'
      }, {
        id: '1',
        label: 'Event#a',
        position: 'x1'
      }, {
        id: '2',
        label: 'Event#x',
        position: 'x2'
      }, {
        id: '3',
        label: 'Event#b',
        position: 'x3'
      }, {
        id: '4',
        label: 'Event#c',
        position: 'x4'
      }, {
        id: '5',
        label: 'Event#y',
        position: 'x5'
      }, {
        id: '6',
        label: 'Event#z',
        position: 'x6'
      }
    ];

    this.hierarchialGraph.links = [
      {
        source: 'start',
        target: '1',
        label: 'Process#1'
      }, {
        source: 'start',
        target: '2',
        label: 'Process#2'
      }, {
        source: '1',
        target: '3',
        label: 'Process#3'
      }, {
        source: '2',
        target: '4',
        label: 'Process#4'
      }, {
        source: '2',
        target: '6',
        label: 'Process#6'
      }, {
        source: '3',
        target: '5'
      }
    ];

  }


}
