import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyingIndexComponent } from './buying-index.component';

describe('BuyingIndexComponent', () => {
  let component: BuyingIndexComponent;
  let fixture: ComponentFixture<BuyingIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyingIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyingIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
