import { TestBed } from '@angular/core/testing';

import { RHelpLineService } from './r-help-line.service';

describe('RHelpLineService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RHelpLineService = TestBed.get(RHelpLineService);
    expect(service).toBeTruthy();
  });
});
