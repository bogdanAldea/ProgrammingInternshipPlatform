import { Component, EventEmitter, Input, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { TrainerDelegateRequest } from 'src/app/domain/internship-hub/internships/TrainerDelegateRequest';
import { TechnologyStack } from 'src/app/domain/internship-hub/technologyStack/TechnologyStack';
import { AbstractForm, AbstractNotifier } from 'src/app/views/components/abstracts/AbstractForm';
import { AbstractInputComponent } from 'src/app/views/components/abstracts/abstract-input/abstract-input.component';
import { FilterDropdownComponent as FilterDropdown } from 'src/app/views/components/dropdowns/filter-dropdown/filter-dropdown.component';
import { AccountsController } from 'src/app/views/controllers/accounts/accounts-controller.service';
import { InternshipsHubController } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';

@Component({
  selector: 'app-trainers-form',
  templateUrl: './trainers-form.component.html',
  styleUrls: ['./trainers-form.component.scss']
})
export class TrainersFormComponent extends AbstractNotifier implements AbstractForm, OnInit{
  public isRequired: boolean | undefined;
  public trainers: PartialAccount[] = [];
  public technologies: TechnologyStack[] = [];

  @ViewChildren(FilterDropdown) trainerDropdowns!: QueryList<FilterDropdown>;

  public constructor(
    private internshipController: InternshipsHubController,
    private accountsController: AccountsController
    ) { super(); }
  
  public ngOnInit(): void {
    this.isRequired = false;
    
    this.internshipController.getAllTechnologies()
      .subscribe((response: TechnologyStack[]) => this.technologies = response);
    
      this.accountsController.getAllAccountsByRole("Trainer")
      .subscribe((response: PartialAccount[]) => this.trainers = response)
  }
  
  public validateForm(): boolean {
    return this.checkIfFieldssHaveBeenFilled(this.trainerDropdowns);
  }
  
  public getFilledDate(): { [key: string]: any; } {
    const data: {[key: string]: any} = {}
    this.trainerDropdowns.forEach(field => {
      data[field.identifier!] = field.getSelectedValue()
    })

    return data;
  }

  public createRequestData = (request: { [key: string]: any }): TrainerDelegateRequest => {
    return {
      accountId: request['trainer'].id,
      technologies: request['technology']
    }
  }

  public sendRequest = (): Observable<any> => {
    return new Observable();
  }

  private checkIfFieldssHaveBeenFilled = (fields: QueryList<AbstractInputComponent>): boolean => {
    let fieldsHaveBeenFilled = false;
    fields.forEach(field => {
      fieldsHaveBeenFilled = field.getSelectedValue() ? true : false;
    })
    return fieldsHaveBeenFilled;
  }

}
