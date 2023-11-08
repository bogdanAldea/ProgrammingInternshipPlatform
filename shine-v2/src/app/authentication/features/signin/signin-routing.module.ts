import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Signin } from './signin.component';

const routes: Routes = [
  {
    path: 'sign-in',
    component: Signin
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SigninRoutingModule { }
