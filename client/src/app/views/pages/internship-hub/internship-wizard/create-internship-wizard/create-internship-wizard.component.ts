import { AfterViewInit, Component, QueryList, ViewChildren } from '@angular/core';
import { SetupFormComponent as SetupForm } from '../form-steps/setup-form/setup-form.component';
import { TrainersFormComponent as TrainersForm } from '../form-steps/trainers-form/trainers-form.component';
import { InternsFormComponent as InternsForm } from '../form-steps/interns-form/interns-form.component';
import { MentorshipsFormComponent as MentorshipsForm } from '../form-steps/mentorships-form/mentorships-form.component';
import { StepComponent } from 'src/app/views/components/steps/step/step.component';

@Component({
  selector: 'app-create-internship-wizard',
  templateUrl: './create-internship-wizard.component.html',
  styleUrls: ['./create-internship-wizard.component.scss']
})
export class CreateInternshipWizardComponent implements AfterViewInit {
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

  @ViewChildren(StepComponent) forms!: QueryList<StepComponent>

  public ngAfterViewInit(): void {
    
  }
}
