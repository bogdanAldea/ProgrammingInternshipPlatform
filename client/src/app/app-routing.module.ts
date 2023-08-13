import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavigationLayoutComponent } from './shared-modules/layouts/navigation-layout/navigation-layout.component';
import { NoNavLayoutComponent } from './shared-modules/layouts/no-nav-layout/no-nav-layout.component';

const routes: Routes = 
[
  {
    path: '',
    component: NavigationLayoutComponent,
    children: [
      {
        path: 'overview',
        loadChildren: () => import('./features/overview/overview.module')
        .then(module => module.OverviewModule)
      },
      {
        path: 'internships',
        loadChildren: () => import('./features/internship-hub/internship-hub.module')
        .then(module => module.InternshipHubModule)
      }
  ]
  },

  {
    path: 'auth',
    component: NoNavLayoutComponent,
    children: [
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
