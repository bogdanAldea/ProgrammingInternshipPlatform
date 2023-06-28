import { Component, Input } from '@angular/core';
import { Internship } from '../../core/models/internship';
import { InternshipStatusAsString } from '../../core/enums/intership-status';

@Component({
  selector: 'app-internship-table',
  templateUrl: './internship-table.component.html',
  styleUrls: ['./internship-table.component.scss']
})
export class InternshipTableComponent {
  @Input() internships: Internship[] | undefined = [];
  status = InternshipStatusAsString;
}
