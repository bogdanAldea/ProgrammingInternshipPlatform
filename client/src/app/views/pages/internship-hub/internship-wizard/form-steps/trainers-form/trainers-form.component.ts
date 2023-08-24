import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';

@Component({
  selector: 'app-trainers-form',
  templateUrl: './trainers-form.component.html',
  styleUrls: ['./trainers-form.component.scss']
})
export class TrainersFormComponent implements AbstractForm {
  public readonly isRequired: boolean = false;

  @Input() trainers: PartialAccount[] = [];
  
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
