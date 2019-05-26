import { TestBed } from '@angular/core/testing';

import { RSymptomService } from './rsymptom.service';

describe('RSymptomService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RSymptomService = TestBed.get(RSymptomService);
    expect(service).toBeTruthy();
  });
});
