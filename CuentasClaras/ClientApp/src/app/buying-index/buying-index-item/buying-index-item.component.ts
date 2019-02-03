import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-buying-index-item',
  templateUrl: './buying-index-item.component.html',
  styleUrls: ['./buying-index-item.component.scss']
})
export class BuyingIndexItemComponent implements OnInit {
  @Input() public indexItem;

  constructor() {
  }

  ngOnInit() {
  }

}
