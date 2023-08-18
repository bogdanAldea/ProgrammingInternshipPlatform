import { Component, Input } from '@angular/core';
import { InputOptions } from '../InputOptions';

@Component({
  selector: 'app-abstract-input',
  templateUrl: './abstract-input.component.html',
  styleUrls: ['./abstract-input.component.scss']
})
export abstract class AbstractInputComponent implements InputOptions {
  @Input() icon: string | undefined;
  @Input() label: string | undefined;
  public selectedValue: string | undefined;
  constructor(){}
}
