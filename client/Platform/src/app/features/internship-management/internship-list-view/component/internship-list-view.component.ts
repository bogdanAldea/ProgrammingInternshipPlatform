import { Component, OnInit } from '@angular/core';
import { InternshipService } from '../services/internship-service.service';
import { InternshipDetails } from '../models/internship-details/internship-details';


@Component({
  selector: 'app-internship-list-view',
  templateUrl: './internship-list-view.component.html',
  styleUrls: ['./internship-list-view.component.scss']
})
export class InternshipListViewComponent implements OnInit {
  constructor(private internshipService: InternshipService) {}

  internships: InternshipDetails[] | undefined;

  ngOnInit(): void {
    // this only for testing
    this.internshipService
      .getAllInternshipsAtOrganisation()
      .subscribe(response => this.internships = response);
  }

}
