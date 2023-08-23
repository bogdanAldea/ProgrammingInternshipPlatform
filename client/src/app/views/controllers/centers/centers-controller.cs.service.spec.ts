import { TestBed } from '@angular/core/testing';

import { CentersControllerCsService } from './centers-controller.cs.service';

describe('CentersControllerCsService', () => {
  let service: CentersControllerCsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CentersControllerCsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
