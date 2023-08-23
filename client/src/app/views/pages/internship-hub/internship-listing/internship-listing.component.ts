import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PartialInternship } from 'src/app/domain/internship-hub/internships/PartialInternship';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';
import { MatDialog } from '@angular/material/dialog';
import { InternshipWizardDialogComponent } from '../internship-wizard/internship-wizard-dialog/internship-wizard-dialog.component';
import { InternshipsHubControllerService } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';
import { CentersControllerService } from 'src/app/views/controllers/centers/centers-controller.cs.service';
import { AccountsController } from 'src/app/views/controllers/accounts/accounts-controller.service';

@Component({
  selector: 'app-internship-listing',
  templateUrl: './internship-listing.component.html',
  styleUrls: ['./internship-listing.component.scss']
})
export class InternshipListingComponent implements OnInit {
  public internships: Observable<PartialInternship[]> | undefined;
  public hasInternships: boolean | undefined;
  public icons = IconRegistrar;

  public constructor(
    private internshipsController: InternshipsHubControllerService,
    private centersController: CentersControllerService,
    private accountsController: AccountsController,
    private dialog: MatDialog
    ) {}
  
  public ngOnInit(): void {
    this.internships = this.internshipsController.getAllInternships();
    this.internships.subscribe(internships => this.hasInternships = internships.length >= 1)
  }

  public openInternshipWizard = () => {
    const coordinators = this.accountsController.getAllAccountsByRole("Coordinator");
    const centers = this.centersController.getAllCenters();
    this.dialog.open(InternshipWizardDialogComponent, 
      {width: "1000px", height: "660px", data: 
        {
          "centers": centers,
          "coordinators": coordinators
        }})
  }

}
