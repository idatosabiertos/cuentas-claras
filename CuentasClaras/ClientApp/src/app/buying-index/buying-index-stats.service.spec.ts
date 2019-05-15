import { TestBed } from '@angular/core/testing';

import { BuyingIndexStatsService } from './buying-index-stats.service';

describe('BuyingIndexStatsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BuyingIndexStatsService = TestBed.get(BuyingIndexStatsService);
    expect(service).toBeTruthy();
  });
});
