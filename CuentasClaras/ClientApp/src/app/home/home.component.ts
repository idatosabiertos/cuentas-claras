import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
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
}
