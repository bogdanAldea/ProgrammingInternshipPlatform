import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { SetupFormComponent as SetupForm } from '../form-steps/setup-form/setup-form.component';
import { TrainersFormComponent as TrainersForm } from '../form-steps/trainers-form/trainers-form.component';
import { InternsFormComponent as InternsForm } from '../form-steps/interns-form/interns-form.component';
import { MentorshipsFormComponent as MentorshipsForm } from '../form-steps/mentorships-form/mentorships-form.component';
import { StepComponent } from 'src/app/views/components/steps/step/step.component';
import { MatStepper } from '@angular/material/stepper';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';
import { InternshipsHubController } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';
import { AccountsController } from 'src/app/views/controllers/accounts/accounts-controller.service';
import { CentersController } from 'src/app/views/controllers/centers/centers-controller.cs.service';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { Center } from 'src/app/domain/internship-hub/centers/center';

@Component({
  selector: 'app-create-internship-wizard',
  templateUrl: './create-internship-wizard.component.html',
  styleUrls: ['./create-internship-wizard.component.scss']
})
export class CreateInternshipWizardComponent {
  public steps = 
  [
    {
      title: 'Setup',
      form: SetupForm,
    },
    {
      title: 'Trainers',
      form: TrainersForm,
    },
    {
      title: 'Interns',
      form: InternsForm,
    },
    {
      title: 'Mentorships',
      form: MentorshipsForm,
    }
  ];

  public centers: Center[] | undefined;
  public coordinators: PartialAccount[] | undefined;

  @ViewChildren(StepComponent) forms!: QueryList<StepComponent>
  @ViewChild(MatStepper) wizardStepper!: MatStepper;
  
  public proceedToNextStep = (): void => {
    const currentForm = this.getCurrentStepForm();
    if (currentForm.isRequired) {
      const isFormValid = currentForm.validateForm();
      if (isFormValid) {
        const request = currentForm.createRequestData(currentForm.getFilledDate());
        currentForm.sendRequest(request).subscribe({
          next: () => {
            this.wizardStepper.next();
          },
          error: (error: any) => {
            console.error('API request failed:', error);
          }
        });
      }
    }
    this.wizardStepper.next();
  }



  private getCurrentStepForm = (): AbstractForm => {
    const indexOfCurrentStep: number = this.wizardStepper.selectedIndex;
    const currentStep: StepComponent | undefined = this.findCurrentStep(indexOfCurrentStep);
    return currentStep?.form as AbstractForm;
  }

  private findCurrentStep = (indexOfCurrentStep: number): StepComponent | undefined => {
    return this.forms.find((_, index) => index === indexOfCurrentStep)
  }
}
