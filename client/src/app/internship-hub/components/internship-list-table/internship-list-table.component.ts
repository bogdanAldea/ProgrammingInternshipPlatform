import { Component, Input } from '@angular/core';
import { InternshipWithCoordinator } from '../../models/internshipWitCoordinator';

@Component({
  selector: 'internship-list-table',
  templateUrl: './internship-list-table.component.html',
  styleUrls: ['./internship-list-table.component.scss']
})
export class InternshipListTable {
  @Input() internships: ReadonlyArray<InternshipWithCoordinator> | undefined;
}
