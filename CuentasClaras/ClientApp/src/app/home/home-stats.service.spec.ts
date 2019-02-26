import { TestBed } from '@angular/core/testing';

import { HomeStatsService } from './home-stats.service';

describe('HomeStatsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HomeStatsService = TestBed.get(HomeStatsService);
    expect(service).toBeTruthy();
  });
});
