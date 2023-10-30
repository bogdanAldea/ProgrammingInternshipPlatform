import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsNavbar } from './settings-navbar/settings-navbar.component';
import { NodeModule } from '../node/node.module';



@NgModule({
  declarations: [
    SettingsNavbar
  ],
  imports: [
    CommonModule,
    NodeModule
  ],
  exports: [SettingsNavbar]
})
export class SettingsNavbarModule { }
