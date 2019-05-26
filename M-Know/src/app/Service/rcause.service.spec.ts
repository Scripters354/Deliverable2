import { TestBed } from '@angular/core/testing';

import { RCauseService } from './rcause.service';

describe('RCauseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RCauseService = TestBed.get(RCauseService);
    expect(service).toBeTruthy();
  });
});
