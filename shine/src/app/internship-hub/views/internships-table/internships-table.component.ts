import { Component, Input } from '@angular/core';
import { InternshipWithCoordinator } from '../../models/internshipWithCoordinator';
import { Router } from '@angular/router';

@Component({
  selector: 'internships-table',
  templateUrl: './internships-table.component.html',
  styleUrls: ['./internships-table.component.scss']
})
export class InternshipsTable {
  @Input() programs: InternshipWithCoordinator[] | undefined;
  constructor(private router: Router) {}


}
