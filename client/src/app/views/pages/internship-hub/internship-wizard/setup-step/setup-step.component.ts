import { AfterViewInit, Component, Input, QueryList, ViewChildren } from '@angular/core';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { Center } from 'src/app/domain/internship-hub/centers/center';
import { InternshipSetupRequest } from 'src/app/domain/internship-hub/internships/InternshipSetupRequest';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';
import { FilterDropdownComponent } from 'src/app/views/components/dropdowns/filter-dropdown/filter-dropdown.component';
import { DatePickerComponent } from 'src/app/views/components/fields/date-picker/date-picker.component';
import { FieldComponent } from 'src/app/views/components/fields/field/field.component';
import { InternshipsHubControllerService } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';

@Component({
  selector: 'app-setup-step',
  templateUrl: './setup-step.component.html',
  styleUrls: ['./setup-step.component.scss']
})
export class SetupStepComponent {
  public isStepFilled: boolean = false;

  @Input() stepTitle: string | undefined;
  @Input() icons = IconRegistrar;
  @Input() centers: Center[] | undefined;
  @Input() coordinators: PartialAccount[] | undefined;

  @ViewChildren(FilterDropdownComponent) dropdowns!: QueryList<FilterDropdownComponent>;
  @ViewChildren(FieldComponent) fields!: QueryList<FieldComponent>;
  @ViewChildren(DatePickerComponent) timeframe! : QueryList<DatePickerComponent>;

  public validate = (): boolean => {
    this.dropdowns.forEach(field => {
      this.isStepFilled = field.getSelectedValue() ? true : false;
    })

    this.fields.forEach(field => {
      this.isStepFilled = field.getSelectedValue() ? true : false;
    })

    this.timeframe.forEach(date => {
      this.isStepFilled = date.getSelectedValue() ? true : false;
    })

    return this.isStepFilled;
  }

  public getDropdownValues = () => {
    const data: {[key: string]: any} = {}
    this.dropdowns.forEach(field => {
      data[field.identifier!] = field.getSelectedValue()
    })

    this.fields.forEach(field => {
      data[field.identifier!] = field.getSelectedValue()
    })

    this.timeframe.forEach(field => {
      data[field.identifier!] = field.getSelectedValue();
    })

    return data;
  }

  public createInternshipSetup = (data: {[key: string]: any}) => {
    var internshipSetupRequest: InternshipSetupRequest = {
      center: data['center'].value,
      coordinatorId: data['coordinator'].id,
      maxInternsToEnroll: parseInt(data['interns']),
      durationInMonths: parseInt(data['duration']),
      scheduledToStartOn: new Date(data['startDate']),
      estimatedToEndOn: data['endDate'] ?? new Date(data['endDate'])
    }
    return internshipSetupRequest;
  }
}
