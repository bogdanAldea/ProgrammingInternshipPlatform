import { Component } from '@angular/core';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';

@Component({
  selector: 'app-trainers-form',
  templateUrl: './trainers-form.component.html',
  styleUrls: ['./trainers-form.component.scss']
})
export class TrainersFormComponent implements AbstractForm {
  public readonly isRequired: boolean = false;
  
  public validateForm(): boolean {
    throw new Error('Method not implemented.');
  }
  
  public getFilledDate(): { [key: string]: any; } {
    throw new Error('Method not implemented.');
  }

}
