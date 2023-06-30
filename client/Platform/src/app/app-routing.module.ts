import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContextLayoutComponent } from './shared/layouts/context-layout/context-layout.component';
import { AuthenticationLayoutComponent } from './shared/layouts/authentication-layout/authentication-layout.component';
import { SignInComponent } from './features/authentication/sign-in/sign-in.component';
import { AdminRegistrationComponent } from './features/authentication/admin-sign-up/admin-registration.component';

const routes: Routes = [
  {
    path: 'user',
    component: ContextLayoutComponent,
    children: [
      {
        path: 'internships',
        loadChildren: () => import('../app/features/internship-management/internship-routing/internship-routing.module')
                                .then(module => module.InternshipRoutingModule)
      }
    ]
  },

  {
    path: '',
    component: AuthenticationLayoutComponent,
    children: [
      {
        path: '',
        component: AdminRegistrationComponent
      },

      {
        path: 'signin',
        component: SignInComponent
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
