import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { Observable } from 'rxjs';
import { InternshipRequest } from 'src/app/core/internship-management/contracts/requests/InternshipRequest';
import { CenterResponse } from 'src/app/core/organisation/contracts/CenterResponse';
import { CountryResponse } from 'src/app/core/organisation/contracts/CountryResponse';
import { OrganisationService } from 'src/app/core/organisation/services/organisation.service';

@Component({
  selector: 'app-add-internship-dialog',
  templateUrl: './add-internship-dialog.component.html',
  styleUrls: ['./add-internship-dialog.component.scss']
})
export class AddInternshipDialogComponent implements OnInit {
  private organisationId: string | undefined;
  public countries$: Observable<CountryResponse[]> | undefined;
  public centers$: Observable<CenterResponse[]> | undefined;
  @Output() newInternshipFormFilledEvent: EventEmitter<InternshipRequest> = new EventEmitter<InternshipRequest>;

  public constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private formBuilder: FormBuilder,
    private organisationService: OrganisationService
  ) 
  {
    this.organisationId = this.data.organisationId
  }
  
  public ngOnInit(): void 
  {
    this.countries$ = this.getAllCountriesFromOrganisation(this.organisationId!);
  }

  public newInternshipForm = this.formBuilder.group({
    countries: [null, [Validators.required]],
    centers: [null, [Validators.required]],
    maximumInternsToEnroll: [3, [Validators.required]],
    durationInMonths: [3, [Validators.required]],
    scheduledToStartOn: [null, [Validators.required]]
  })

  private getAllCountriesFromOrganisation = (organisationId: string): Observable<CountryResponse[]> => {
    return this.organisationService.getAllCountriesAtOrganisation(organisationId);
  }

  public getAllCentersFromSelectedCountry = (selectedCountryEvent: MatSelectChange): void => {
    const selectedCountry: CountryResponse = selectedCountryEvent.value as CountryResponse;
    this.centers$ =  this.organisationService.getAllCentersInCountry(this.organisationId!, selectedCountry.id);
    this.centers$.subscribe(x => console.log(x))
  }

  public getSelectedCountry = (): string => {
    const data =  this.newInternshipForm.get('countries')!.value! as CountryResponse
    return data ? data.name : '';
  }

  public getSelectedCenter = (): string => {
    const data =  this.newInternshipForm.get('centers')!.value! as CenterResponse
    return data ? data.location : '';
  }

  public getInternshipFormData = () => {
    const center: CenterResponse = this.newInternshipForm.get('centers')!.value!;
    let internshipRequest: InternshipRequest | undefined;
      internshipRequest = {
        companyId: this.organisationId!,
        locationId: center.id,
        maximumInternsToEnroll: this.newInternshipForm.get('maximumInternsToEnroll')!.value!,
        durationInMonths: this.newInternshipForm.get('durationInMonths')!.value!,
        scheduledToStartOnDate: this.newInternshipForm.get('scheduledToStartOn')!.value!,
    }
    this.newInternshipFormFilledEvent.emit(internshipRequest);
  }

}
