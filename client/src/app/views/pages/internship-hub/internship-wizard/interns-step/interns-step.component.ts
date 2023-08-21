import { Component, Input } from '@angular/core';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-interns-step',
  templateUrl: './interns-step.component.html',
  styleUrls: ['./interns-step.component.scss']
})
export class InternsStepComponent {
  @Input() stepTitle: string | undefined;
  @Input() icons = IconRegistrar;
  @Input() selectedIntern: undefined;
}
