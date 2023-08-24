import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PartialAccount } from 'src/app/domain/accounts/PartialAccount';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';

@Component({
  selector: 'app-interns-form',
  templateUrl: './interns-form.component.html',
  styleUrls: ['./interns-form.component.scss']
})
export class InternsFormComponent implements AbstractForm {
  public readonly isRequired: boolean = false;

  @Input() interns: PartialAccount[] = [];
  
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
