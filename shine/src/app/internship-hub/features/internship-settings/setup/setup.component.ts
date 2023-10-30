import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { PartialInternship } from 'src/app/internship-hub/models/partialInternship';
import { CenterService } from 'src/app/internship-hub/services/center/center.service';
import { InternshipService } from 'src/app/internship-hub/services/internship/internship.service';
import { BasePage } from 'src/app/shared/components/abstracts/basePage';
import { EnumToListConverter } from 'src/app/shared/enums/convertionHelper/enumConversionHelper';
import { InternshipStatus } from 'src/app/shared/enums/internship-status/internshipStatus';
import { ConvertedFromEnum } from 'src/app/shared/models/convertedFromEnum';

@Component({
  selector: 'setup',
  templateUrl: './setup.component.html',
  styleUrls: ['./setup.component.scss']
})
export class SetupComponent extends BasePage implements OnInit {
  public internshipConfiguration: PartialInternship | undefined;
  public centers: ConvertedFromEnum[] | undefined;
  public status: ConvertedFromEnum[] = EnumToListConverter.convert(InternshipStatus);
  public isLocationButtonDisabled = true;
  public isStatusButtonDisabled = true;
  public isTimeframeButtonDisabled = true;
  
  public constructor(
    router: ActivatedRoute, 
    private readonly internshipService: InternshipService,
    private readonly centersService: CenterService) { super(router) }

  public ngOnInit(): void {
    this.isLoading = true;
    this.parentGuid = this.getParentIdFromRoute();
    
    if (this.parentIdExistsOnRoute(this.parentGuid)) {
      const configuration = this.getInternshipgetInternshipSetupConfiguration(this.parentGuid!);
      const centers = this.getAllCenters();

      forkJoin([configuration, centers]).subscribe(
        ([configuration, centers]) => {
          this.internshipConfiguration = configuration;
          this.centers = centers;
          this.isLoading = false;
        }
      )
    }
  }

  private getInternshipgetInternshipSetupConfiguration = (internshipGuid: string): Observable<PartialInternship> =>
    this.internshipService.getInternshipSetupConfiguration(internshipGuid)

  private getAllCenters = (): Observable<ConvertedFromEnum[]> => 
    this.centersService.getAllCentersAtOrganisation();
}
