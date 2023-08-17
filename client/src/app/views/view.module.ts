import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownsModule } from './components/dropdowns/dropdowns.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ApplicationModule,
    DropdownsModule
  ]
})
export class ViewModule { }
