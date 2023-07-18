import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavLayoutComponent } from './shared/layouts/nav-layout/nav-layout.component';
import { NoNavLayoutComponent } from './shared/layouts/no-nav-layout/no-nav-layout.component';

const routes: Routes = 
[
  {
    path: '',
    component: NavLayoutComponent,
    children: 
    [
      {
        path: 'accounts',
        loadChildren: () => import('./features/accounts/accounts.module')
        .then(module => module.AccountsModule)
      }
    ]
  },

  {
    path: 'auth',
    component: NoNavLayoutComponent,
    children: 
    [
      {
        path: '',
        loadChildren: () => import('./features/authentication/authentication.module')
        .then(module => module.AuthenticationModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
