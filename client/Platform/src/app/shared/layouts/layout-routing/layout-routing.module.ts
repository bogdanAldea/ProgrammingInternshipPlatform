import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationLayoutComponent } from '../authentication-layout/authentication-layout.component';

const routes: Routes = 
[
  {
    path: 'authentication',
    component: AuthenticationLayoutComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
