import { Component, Input } from '@angular/core';
import { Pagination } from 'src/app/shared/services/types';
import { Internship } from '../../models/internship';

@Component({
  selector: 's-internship-table',
  templateUrl: './internships-table.component.html',
  styleUrls: ['./internships-table.component.scss']
})
export class InternshipListTable {
  @Input() internshipResponse: Pagination<Internship> | undefined;
}
