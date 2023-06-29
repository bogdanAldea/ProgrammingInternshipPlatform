import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContextLayoutComponent } from './shared/layouts/context-layout/context-layout.component';
import { AuthenticationLayoutComponent } from './shared/layouts/authentication-layout/authentication-layout.component';
import { AdminRegistrationComponent } from './features/authencation/admin-registration/admin-registration.component';

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
        path: 'registration',
        component: AdminRegistrationComponent
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
