import { Component } from '@angular/core';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';

@Component({
  selector: 'app-interns-form',
  templateUrl: './interns-form.component.html',
  styleUrls: ['./interns-form.component.scss']
})
export class InternsFormComponent implements AbstractForm {
  public readonly isRequired: boolean = false;
  
  public validateForm(): boolean {
    throw new Error('Method not implemented.');
  }
  
  public getFilledDate(): { [key: string]: any; } {
    throw new Error('Method not implemented.');
  }

}
