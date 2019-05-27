import { TestBed } from '@angular/core/testing';

import { RFAQsService } from './r-faqs.service';

describe('RFAQsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RFAQsService = TestBed.get(RFAQsService);
    expect(service).toBeTruthy();
  });
});
