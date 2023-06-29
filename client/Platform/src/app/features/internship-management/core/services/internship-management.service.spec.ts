import { TestBed } from '@angular/core/testing';

import { InternshipManagementService } from './internship-management.service';

describe('InternshipManagementService', () => {
  let service: InternshipManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InternshipManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
