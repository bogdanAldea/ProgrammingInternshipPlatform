import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { ParticipantToSelect } from 'src/app/domain/internship-hub/mentorship-participants/ParticipantToSelect';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-mentorship-participant-card',
  templateUrl: './mentorship-participant-card.component.html',
  styleUrls: ['./mentorship-participant-card.component.scss']
})
export class MentorshipParticipantCardComponent {
  @Input() participant?: ParticipantToSelect | undefined;
  @Input() height: string = '63px';
  @Input() width: string = '63px';
  public icon = IconRegistrar.Add.Brand;
}
