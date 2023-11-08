import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SidebarLayoutComponent } from '../shineUI/layouts/sidebar-layout/sidebar-layout.component';
import { ErrorPage } from '../error-page/features/error-page/error.page.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        loadChildren : () => import('../authentication/features/authentication-shell/authentication-shell.module')
        .then(module => module.AuthenticationShellModule)
      }
    ]
  },
  {
    path: '',
    component: SidebarLayoutComponent,
    children: [
      {
        path: 'error',
        component: ErrorPage
      },
      
      {
        path: 'internship-hub',
        loadChildren: () => import('../internships/features/interships-shell/interships-shell.module')
        .then(module => module.IntershipsShellModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
