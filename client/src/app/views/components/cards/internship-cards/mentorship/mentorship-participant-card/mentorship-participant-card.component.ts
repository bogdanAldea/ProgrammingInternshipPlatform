import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-mentorship-participant-card',
  templateUrl: './mentorship-participant-card.component.html',
  styleUrls: ['./mentorship-participant-card.component.scss']
})
export class MentorshipParticipantCardComponent {
  @Input() role: string | undefined;
  @Input() pictureUrl: string | undefined;
  @Input() username: string | undefined;
  @Input() email: string | undefined;
}
