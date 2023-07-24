import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { InternshipRequest } from 'src/app/core/internship-management/contracts/requests/InternshipRequest';
import { FullInternship } from 'src/app/core/internship-management/models/enums/FullInternship';
import { InternshipService } from 'src/app/core/internship-management/services/internship.service';
import { OrganisationService } from 'src/app/core/organisation/services/organisation.service';
import { AddInternshipDialogComponent } from 'src/app/shared/dialogs/add-internship-dialog/add-internship-dialog.component';

@Component({
  selector: 'app-internship-listing',
  templateUrl: './internship-listing.component.html',
  styleUrls: ['./internship-listing.component.scss']
})
export class InternshipListingComponent implements OnInit {
  public internships$: Observable<FullInternship[]> | undefined;

  public ngOnInit(): void {
    this.internships$ = this.getAllInternshipsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
  }

  public constructor(
    private organisationService: OrganisationService,
    private internshipService: InternshipService,
    private dialog: MatDialog
    ) {}

  public addInternship = () => {
    const config: MatDialogConfig = new MatDialogConfig();
    config.position = {right: '0'}
    config.height = '100%';
    config.width = '500px';
    config.data = {organisationId: 'b4f75fed-37bf-40fc-a8b3-f071b41a3fc1'}
    const dialogRef = this.dialog.open(AddInternshipDialogComponent, config)
    dialogRef.componentInstance.newInternshipFormFilledEvent.subscribe((request: InternshipRequest) => {
      this.internshipService.addNewInternship(request).subscribe({
        next: () => {
          this.internships$ = this.getAllInternshipsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
        },
        error: error => {
          console.log(error);
        }
      })
    })

  }
  
  private getAllInternshipsAtOrganisation = (organisationId: any): Observable<FullInternship[]> => {
    return this.organisationService.getAllInternshipsAtOrganisation(organisationId);
  }

}
