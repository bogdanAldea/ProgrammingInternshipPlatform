import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInternshipWizardComponent } from './create-internship-wizard.component';

describe('CreateInternshipWizardComponent', () => {
  let component: CreateInternshipWizardComponent;
  let fixture: ComponentFixture<CreateInternshipWizardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateInternshipWizardComponent]
    });
    fixture = TestBed.createComponent(CreateInternshipWizardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
