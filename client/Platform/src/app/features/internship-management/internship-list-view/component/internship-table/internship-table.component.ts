import { Component, Input } from '@angular/core';
import { InternshipDetails } from '../../models/internship-details/internship-details';
import { InternshipStatusAsString } from '../../../enums/internship-status';

@Component({
  selector: 'app-internship-table',
  templateUrl: './internship-table.component.html',
  styleUrls: ['./internship-table.component.scss']
})
export class InternshipTableComponent {
  @Input() internships: InternshipDetails[] | undefined = [];
  status = InternshipStatusAsString;
}
