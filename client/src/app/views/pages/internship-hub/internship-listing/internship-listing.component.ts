import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IGEtAllInternships } from 'src/app/application/internship-hub/get-all-internships/IGetAllInternships';
import { PartialInternship } from 'src/app/domain/internship-hub/internships/PartialInternship';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-internship-listing',
  templateUrl: './internship-listing.component.html',
  styleUrls: ['./internship-listing.component.scss']
})
export class InternshipListingComponent implements OnInit {
  public internships: Observable<PartialInternship[]> | undefined;
  public hasInternships: boolean | undefined;
  public icons = IconRegistrar;

  public constructor(private handler: IGEtAllInternships) {}
  
  public ngOnInit(): void {
    this.internships = this.handler.execute();
    this.internships.subscribe(internships => this.hasInternships = internships.length >= 1)
  }

}
