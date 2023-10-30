import { Component, Input } from '@angular/core';
import { Member } from 'src/app/internship-hub/models/member';
import { CardRenderOptions } from 'src/app/shared/configurations/component-options/cardOptions';

@Component({
  selector: 'mentorship-member-card',
  templateUrl: './mentorship-member-card.component.html',
  styleUrls: ['./mentorship-member-card.component.scss']
})
export class MentorshipMemberCard {
  @Input() member?: Member;
  @Input() options: CardRenderOptions = {
    height: '63px',
    width: '63px'
  };
  public addActionIcon: string = '../../../../../../assets/icons/purple/Actions/Add.svg';
}
