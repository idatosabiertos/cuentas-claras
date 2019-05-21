import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YearFilterComponent } from './year-filter.component';

describe('YearFilterComponent', () => {
  let component: YearFilterComponent;
  let fixture: ComponentFixture<YearFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YearFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YearFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
