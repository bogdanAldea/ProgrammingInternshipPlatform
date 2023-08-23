import { Component, ViewChild, Inject, ViewChildren, QueryList } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatStep, MatStepper } from '@angular/material/stepper';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { Center } from 'src/app/domain/internship-hub/centers/center';
import { SetupStepComponent } from '../setup-step/setup-step.component';
import { InternshipsHubControllerService } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';

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
    @Inject(MAT_DIALOG_DATA) public data: any,
    private internshipController: InternshipsHubControllerService) 
  {
    this.data.centers.subscribe((centers: Center[]) => this.centers = centers);
    this.data.coordinators.subscribe((coordinators: PartialAccount[]) => this.coordinators = coordinators);
  }

  public proceedToNextStep = (): void => {
    if (this.isSetupValid()) {
      const data = this.setup.getDropdownValues();
      const request = this.setup.createInternshipSetup(data);
      this.internshipController.createInternshipSetup(request).subscribe({
        next: () => {
          this.wizardStepper.next();
        },
        error: (error: any) => {
          console.error('API request failed:', error);
        }
      });
    }
  }

  private isSetupValid = (): boolean => {
    return this.setup.validate();
  }
  
}
