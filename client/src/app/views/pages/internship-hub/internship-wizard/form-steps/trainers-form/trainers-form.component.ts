import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { TechnologyStack } from 'src/app/domain/internship-hub/technologyStack/TechnologyStack';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';
import { AccountsController } from 'src/app/views/controllers/accounts/accounts-controller.service';
import { InternshipsHubController } from 'src/app/views/controllers/internship-hub/internships-hub-controller.cs.service';

@Component({
  selector: 'app-trainers-form',
  templateUrl: './trainers-form.component.html',
  styleUrls: ['./trainers-form.component.scss']
})
export class TrainersFormComponent implements AbstractForm, OnInit {
  public isRequired: boolean | undefined;
  public trainers: PartialAccount[] = [];
  public technologies: TechnologyStack[] = [];

  public constructor(
    private internshipController: InternshipsHubController,
    private accountsController: AccountsController
    ) {}
  
  public ngOnInit(): void {
    this.isRequired = false;
    
    this.internshipController.getAllTechnologies()
      .subscribe((response: TechnologyStack[]) => this.technologies = response);
    
      this.accountsController.getAllAccountsByRole("Trainer")
      .subscribe((response: PartialAccount[]) => this.trainers = response)
  }
  
  public validateForm(): boolean {
    return true;
  }
  
  public getFilledDate(): { [key: string]: any; } {
    return {}
  }

  public createRequestData = () => {}

  public sendRequest = (): Observable<any> => {
    return new Observable();
  }

}
