import { Component, Input } from '@angular/core';
import { InternshipStatusAsString } from 'src/app/features/internship-management/core/enums/internship-status';
import { Internship } from 'src/app/features/internship-management/core/models/internship';

@Component({
  selector: 'app-internships-table',
  templateUrl: './internships-table.component.html',
  styleUrls: ['./internships-table.component.scss']
})
export class InternshipsTableComponent {
  @Input() internships: Internship[] | undefined;
  status = InternshipStatusAsString;
}
