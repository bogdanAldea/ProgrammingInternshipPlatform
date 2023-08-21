import { Component, Input } from '@angular/core';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-mentorships-step',
  templateUrl: './mentorships-step.component.html',
  styleUrls: ['./mentorships-step.component.scss']
})
export class MentorshipsStepComponent {
  @Input() stepTitle: string | undefined;
  @Input() icons = IconRegistrar;
  @Input() selectedIntern: ParticipantToSelect | undefined;
  @Input() selectedTrainer: ParticipantToSelect | undefined;
  @Input() createdMentorshipPairs: undefined;
  @Input() canCreatePairs: boolean = true;
}
