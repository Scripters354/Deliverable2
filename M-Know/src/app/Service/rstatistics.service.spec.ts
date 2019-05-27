import { TestBed } from '@angular/core/testing';

import { RStatisticsService } from './rstatistics.service';

describe('RStatisticsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RStatisticsService = TestBed.get(RStatisticsService);
    expect(service).toBeTruthy();
  });
});
