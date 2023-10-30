import { TestBed } from '@angular/core/testing';

import { GeneralCurriculumService } from './general-curriculum.service';

describe('GeneralCurriculumService', () => {
  let service: GeneralCurriculumService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralCurriculumService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
