import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyingIndexItemComponent } from './buying-index-item.component';

describe('BuyingIndexItemComponent', () => {
  let component: BuyingIndexItemComponent;
  let fixture: ComponentFixture<BuyingIndexItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyingIndexItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyingIndexItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
