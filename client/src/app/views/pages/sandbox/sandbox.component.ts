import { Component, OnInit } from '@angular/core';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';


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

  public selectedIntern: ParticipantToSelect = {
    fullName: 'User Name',
    role: 'Intern',
    email: 'intern@gmail.com',
    pictureUrl: '../../../../assets/images/profile/profile-pic.jpg'
  }
  
}
