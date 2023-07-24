import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FullInternship } from 'src/app/core/internship-management/models/enums/FullInternship';
import { OrganisationService } from 'src/app/core/organisation/services/organisation.service';

@Component({
  selector: 'app-internship-listing',
  templateUrl: './internship-listing.component.html',
  styleUrls: ['./internship-listing.component.scss']
})
export class InternshipListingComponent implements OnInit {
  public internships$: Observable<FullInternship[]> | undefined;

  public ngOnInit(): void {
    this.internships$ = this.getAllInternshipsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
    this.internships$.subscribe(x => console.log(x))
  }

  public constructor(private organisationService: OrganisationService) {}

  private getAllInternshipsAtOrganisation = (organisationId: string): Observable<FullInternship[]> => {
    return this.organisationService.getAllInternshipsAtOrganisation(organisationId);
  }

}
