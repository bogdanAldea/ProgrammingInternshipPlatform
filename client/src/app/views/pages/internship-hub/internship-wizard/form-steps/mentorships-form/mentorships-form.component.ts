import { Component, Input } from '@angular/core';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';

@Component({
  selector: 'app-mentorships-form',
  templateUrl: './mentorships-form.component.html',
  styleUrls: ['./mentorships-form.component.scss']
})
export class MentorshipsFormComponent {
  @Input() canCreatePairs: boolean = true;
  @Input() selectedIntern: ParticipantToSelect | undefined;
  @Input() selectedTrainer: ParticipantToSelect | undefined;
  @Input() createdMentorshipPairs: undefined;
}
