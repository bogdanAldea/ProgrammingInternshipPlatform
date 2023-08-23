import { Component, ViewChild } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'app-internship-wizard-dialog',
  templateUrl: './internship-wizard-dialog.component.html',
  styleUrls: ['./internship-wizard-dialog.component.scss']
})
export class InternshipWizardDialogComponent {
  @ViewChild(MatStepper) wizardStepper!: MatStepper;

  public proceedToNextStep = (): void => {
    this.wizardStepper.next();
  }
}
