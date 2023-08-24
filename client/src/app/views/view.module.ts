import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownsModule } from './components/dropdowns/dropdowns.module';
import { FieldsModule } from './components/fields/fields.module';
import { ComposeDirective } from './directives/compose.directive';



@NgModule({
  declarations: [
    ComposeDirective
  ],
  imports: [
    CommonModule,
    ApplicationModule,
    DropdownsModule,
    FieldsModule,
  ]
})
export class ViewModule { }
