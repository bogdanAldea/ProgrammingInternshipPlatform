import { Component, ViewChild, Inject, ViewChildren, QueryList } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatStep, MatStepper } from '@angular/material/stepper';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { Center } from 'src/app/domain/internship-hub/centers/center';
import { SetupStepComponent } from '../setup-step/setup-step.component';

@Component({
  selector: 'app-internship-wizard-dialog',
  templateUrl: './internship-wizard-dialog.component.html',
  styleUrls: ['./internship-wizard-dialog.component.scss']
})
export class InternshipWizardDialogComponent {
  public centers: Center[] | undefined;
  public coordinators: PartialAccount[] | undefined;
  
  @ViewChild(MatStepper) wizardStepper!: MatStepper;
  @ViewChild(SetupStepComponent) setup!: SetupStepComponent;

  public constructor(
    @Inject(MAT_DIALOG_DATA) public data: any) 
  {
    this.data.centers.subscribe((centers: Center[]) => this.centers = centers);
    this.data.coordinators.subscribe((coordinators: PartialAccount[]) => this.coordinators = coordinators);
  }

  public proceedToNextStep = (): void => {
    if (this.isSetupValid()) {
      this.setup.getDropdownValues();
      // this.wizardStepper.next();
    }
  }

  private isSetupValid = (): boolean => {
    return this.setup.validate();
  }
  
}
