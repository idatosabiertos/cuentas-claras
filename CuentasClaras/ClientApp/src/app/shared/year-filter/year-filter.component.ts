import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-year-filter',
  templateUrl: './year-filter.component.html',
  styleUrls: ['./year-filter.component.scss']
})
export class YearFilterComponent implements OnInit {
  @Input() years: string[];
  @Input() defaultYear: string;
  @Output() selectedYear: EventEmitter<string> = new EventEmitter<string>()
  selected: string;

  public ngOnInit() {
    this.selected = this.defaultYear;
  }

  public selectYear(year: string) {
    this.selected = year;
    this.selectedYear.emit(year);
  }
}
