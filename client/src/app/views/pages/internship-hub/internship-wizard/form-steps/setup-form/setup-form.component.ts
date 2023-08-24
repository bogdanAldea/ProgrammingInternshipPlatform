import { AfterViewInit, Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';
import { AbstractForm } from 'src/app/views/components/abstracts/AbstractForm';
import { InputOptions } from 'src/app/views/components/abstracts/InputOptions';

@Component({
  selector: 'app-setup-form',
  templateUrl: './setup-form.component.html',
  styleUrls: ['./setup-form.component.scss']
})
export class SetupFormComponent implements OnInit, AfterViewInit, AbstractForm {
  public readonly isRequired: boolean = true;
  public icons: any;
  @ViewChildren("#field") fields!: QueryList<InputOptions>;

  public ngOnInit(): void {
    this.icons = IconRegistrar;
  }

  public ngAfterViewInit(): void {
    
  }

  validateForm(): boolean {
    this.fields.forEach(x => console.log(x.selectedValue))
    return true;
  }
  getFilledDate(): { [key: string]: any; } {
    throw new Error('Method not implemented.');
  }
}
