import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipWizardDialogComponent } from './internship-wizard-dialog.component';

describe('InternshipWizardDialogComponent', () => {
  let component: InternshipWizardDialogComponent;
  let fixture: ComponentFixture<InternshipWizardDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipWizardDialogComponent]
    });
    fixture = TestBed.createComponent(InternshipWizardDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
