import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutWithNavigationComponent } from './shared/layouts/layout-with-navigation/layout-with-navigation.component';
import { LayoutWithoutNavigationComponent } from './shared/layouts/layout-without-navigation/layout-without-navigation.component';

const routes: Routes = 
[
  {
    path: 'home',
    component: LayoutWithNavigationComponent,
    children: [
      {
        path: 'internships',
        loadChildren: () => import('./features/internship-management/internship-management.module').then(module => module.InternshipManagementModule)
      },

      {
        path: 'accounts',
        loadChildren: () => import('./features/accounts-management/accounts-management.module').then(module => module.AccountsManagementModule)
      }
    ]
  },

  {
    path: 'auth',
    component: LayoutWithoutNavigationComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./features/authentication/authentication.module').then(module => module.AuthenticationModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
