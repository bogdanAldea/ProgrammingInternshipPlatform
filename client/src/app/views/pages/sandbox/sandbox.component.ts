import { Component } from '@angular/core';
import { SetupStepComponent } from '../internship-hub/internship-wizard/setup-step/setup-step.component';

@Component({
  selector: 'app-sandbox',
  templateUrl: './sandbox.component.html',
  styleUrls: ['./sandbox.component.scss'],
})
export class SandboxComponent {
  public taskDeadline: Date = new Date('06-23-1993');
  public pictureUrl: string = "../../../assets/images/profile/profile-pic.jpg";
  public assigneeName: string = "Michael Scott"
  public dropdownOptions: string[] = [
    'Option A', 'Option B', 'Option C'
  ]
}
