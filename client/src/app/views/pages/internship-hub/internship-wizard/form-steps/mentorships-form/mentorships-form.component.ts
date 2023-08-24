import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';

@Component({
  selector: 'app-mentorships-form',
  templateUrl: './mentorships-form.component.html',
  styleUrls: ['./mentorships-form.component.scss']
})
export class MentorshipsFormComponent implements AbstractForm {
  public readonly isRequired: boolean = false;

  @Input() canCreatePairs: boolean = true;
  @Input() selectedIntern: ParticipantToSelect | undefined;
  @Input() selectedTrainer: ParticipantToSelect | undefined;
  @Input() createdMentorshipPairs: undefined;

  public validateForm(): boolean {
    return true;
  }

  public getFilledDate(): { [key: string]: any; } {
    return {}
  }

  public createRequestData = () => {}

  public sendRequest = ():Observable<any> => {
    return new Observable();
  }
}
