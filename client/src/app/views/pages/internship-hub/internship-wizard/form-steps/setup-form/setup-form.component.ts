import { AfterViewInit, Component, ElementRef, Input, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Observable } from 'rxjs';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { Center } from 'src/app/domain/internship-hub/centers/center';
import { InternshipSetupRequest } from 'src/app/domain/internship-hub/internships/InternshipSetupRequest';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';
import { AbstractInputComponent } from 'src/app/views/components/abstracts/abstract-input/abstract-input.component';
import { FilterDropdownComponent } from 'src/app/views/components/dropdowns/filter-dropdown/filter-dropdown.component';
import { DatePickerComponent } from 'src/app/views/components/fields/date-picker/date-picker.component';
import { FieldComponent } from 'src/app/views/components/fields/field/field.component';
import { AccountsController } from 'src/app/views/controllers/accounts/accounts-controller.service';
import { CentersController } from 'src/app/views/controllers/centers/centers-controller.cs.service';
import { InternshipsHubController } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';
import { FieldType } from 'src/app/views/helpers/FieldType';
import { FieldValueConverter } from 'src/app/views/helpers/FieldValueConverter';

@Component({
  selector: 'app-setup-form',
  templateUrl: './setup-form.component.html',
  styleUrls: ['./setup-form.component.scss']
})
export class SetupFormComponent implements OnInit, AfterViewInit, AbstractForm {
  public fieldType = FieldType
  public isRequired: boolean | undefined;
  public icons: any;

  centers: Center[] = [];
  coordinators: PartialAccount[] = [];
  
  @ViewChildren(FilterDropdownComponent) dropdowns!: QueryList<FilterDropdownComponent>;
  @ViewChildren(FieldComponent) fields!: QueryList<FilterDropdownComponent>;
  @ViewChildren(DatePickerComponent) timeframe! : QueryList<DatePickerComponent>;

  public constructor(
    private centersController: CentersController,
    private accountsController: AccountsController,
    private internshipController: InternshipsHubController
  ) {}


  public ngOnInit(): void {
    this.icons = IconRegistrar;
    this.isRequired = true;

    this.centersController.getAllCenters()
    .subscribe((centers: Center[]) => this.centers = centers)

    this.accountsController.getAllAccountsByRole("Coordinator")
    .subscribe((accounts: PartialAccount[]) => this.coordinators = accounts)
  }

  public ngAfterViewInit(): void {
    this.isRequired = true;
  }

  public sendRequest = (request: InternshipSetupRequest): Observable<string> => {
    return this.internshipController.createInternshipSetup(request)
  }

  public validateForm(): boolean {
    let isFormFilledAndValid: boolean = false;
    isFormFilledAndValid = this.checkIfFieldssHaveBeenFilled(this.dropdowns)
    isFormFilledAndValid = this.checkIfFieldssHaveBeenFilled(this.fields)
    isFormFilledAndValid = this.checkIfFieldssHaveBeenFilled(this.timeframe)
    return isFormFilledAndValid;
  }

  private checkIfFieldssHaveBeenFilled = (fields: QueryList<AbstractInputComponent>): boolean => {
    let fieldsHaveBeenFilled = false;
    fields.forEach(field => {
      fieldsHaveBeenFilled = field.getSelectedValue() ? true : false;
    })
    return fieldsHaveBeenFilled;
  }

  public getFilledDate(): { [key: string]: any; } {
    const data: {[key: string]: any} = {}
    this.dropdowns.forEach(field => {
      data[field.identifier!] = field.getSelectedValue()
    })

    this.fields.forEach(field => {
      data[field.identifier!] = field.getSelectedValue(FieldValueConverter.convertValue)
    })

    this.timeframe.forEach(field => {
      data[field.identifier!] = field.getSelectedValue(FieldValueConverter.toDate);
    })

    return data;
  }

  public createRequestData = (requestData: { [key: string]: any }): InternshipSetupRequest => {
    console.log(requestData['coordinator'])
    var internshipSetupRequest: InternshipSetupRequest = {
      center: requestData['center'].value,
      coordinatorId: requestData['coordinator'].id,
      maxInternsToEnroll: parseInt(requestData['interns']),
      durationInMonths: parseInt(requestData['duration']),
      scheduledToStartOn: new Date(requestData['startDate']),
      estimatedToEndOn: requestData['endDate'] ?? new Date(requestData['endDate'])
    }
    return internshipSetupRequest;
  }
  
}
