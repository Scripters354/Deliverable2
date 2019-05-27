import { TestBed } from '@angular/core/testing';

import { RPreventionService } from './rprevention.service';

describe('RPreventionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RPreventionService = TestBed.get(RPreventionService);
    expect(service).toBeTruthy();
  });
});
