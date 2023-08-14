import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-mentorship-task-card',
  templateUrl: './mentorship-task-card.component.html',
  styleUrls: ['./mentorship-task-card.component.scss']
})
export class MentorshipTaskCardComponent {
  @Input() isTodo: boolean = true;
  @Input() statusName: string = 'To do';
  @Input() taskType: string = 'Mentorship';
  @Input() taskTitle: string| undefined;
  @Input() deadline: Date | undefined;
  @Input() assigneePicture: string | undefined;
  @Input() assigneeName: string | undefined;
}
