import { TestBed } from '@angular/core/testing';

import { InternshipServiceService } from './internship-service.service';

describe('InternshipServiceService', () => {
  let service: InternshipServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InternshipServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
