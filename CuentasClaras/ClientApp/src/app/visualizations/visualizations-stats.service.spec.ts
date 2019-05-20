import { TestBed } from '@angular/core/testing';

import { VisualizationsStatsService } from './visualizations-stats.service';

describe('VisualizationsStatsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VisualizationsStatsService = TestBed.get(VisualizationsStatsService);
    expect(service).toBeTruthy();
  });
});
