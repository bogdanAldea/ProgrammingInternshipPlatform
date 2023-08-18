import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownsModule } from './components/dropdowns/dropdowns.module';
import { FieldsModule } from './components/fields/fields.module';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    ApplicationModule,
    DropdownsModule,
    FieldsModule
  ]
})
export class ViewModule { }
