import { Component, OnInit } from '@angular/core';
import { Internship } from '../core/models/internship';
import { InternshipServiceService } from '../core/services/internship-service.service';

@Component({
  selector: 'app-internship-listing',
  templateUrl: './internship-listing.component.html',
  styleUrls: ['./internship-listing.component.scss']
})
export class InternshipListingComponent implements OnInit {
  public internships: Internship[] | undefined;

  public constructor(private service: InternshipServiceService) {}
  
  public ngOnInit(): void {
    this.service.getAllInternshipsAtOrganisation()
    .subscribe(internships => {
      this.internships = internships
      console.log(this.internships)
    });
  }
}
