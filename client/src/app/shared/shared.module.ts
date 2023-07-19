import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoNavLayoutComponent } from './layouts/no-nav-layout/no-nav-layout.component';
import { NavLayoutComponent } from './layouts/nav-layout/nav-layout.component';
import { UserControlsNavComponent } from './navigations/user-controls-nav/user-controls-nav.component';
import { MenuNavComponent } from './navigations/menu-nav/menu-nav.component';
import { RouterModule } from '@angular/router';
import { TitleComponent } from './typography/title/title.component';
import { ParagraphComponent } from './typography/paragraph/paragraph.component';
import { ButtonComponent } from './buttons/button/button.component';
import { AccountsTableComponent } from './tables/accounts-table/accounts-table.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RoleButtonComponent } from './buttons/role-button/role-button.component';
import { UserRoleDialogComponent } from './dialogs/user-role-dialog/user-role-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';


@NgModule({
  declarations: [
    NoNavLayoutComponent,
    NavLayoutComponent,
    UserControlsNavComponent,
    MenuNavComponent,
    TitleComponent,
    ParagraphComponent,
    ButtonComponent,
    AccountsTableComponent,
    RoleButtonComponent,
    UserRoleDialogComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatSelectModule,
    MatFormFieldModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatCheckboxModule
  ],
  exports: [
    TitleComponent, 
    ParagraphComponent,
    ButtonComponent,
    AccountsTableComponent
  ]
})
export class SharedModule { }
