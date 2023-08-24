import { TestBed } from '@angular/core/testing';

import { InternshipsHubControllerCsService } from './internships-hub-controller.cs.service';

describe('InternshipsHubControllerCsService', () => {
  let service: InternshipsHubControllerCsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InternshipsHubControllerCsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
