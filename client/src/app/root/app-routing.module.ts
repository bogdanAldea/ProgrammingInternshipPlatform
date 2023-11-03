import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SidebarLayout } from '../shared/components/layouts/sidebar-layout/sidebar-layout.component';

const routes: Routes = 
[
  {
    path: 'authentication',
    loadChildren: () => import('../authentication/feature/authentication-shell/authentication-shell.module')
    .then(module => module.AuthenticationShellModule)
  },
  
  {
    path: '',
    component: SidebarLayout,
    children: [
      {
        path: 'general-topics',
        loadChildren: () => import('../general-curriculum/features/general-curriculum-shell/general-curriculum-shell.module')
        .then(module => module.GeneralCurriculumShellModule)
      }, 

      {
        path: 'internship-hub',
        loadChildren: () => import('../internship-hub/features/internship-hub-shell/internship-hub-shell.module')
        .then(module => module.InternshipHubShellModule)
      },
      
      {
        path: 'error',
        loadChildren: () => import('../error-page/features/error-page-shell/error-page-shell.module')
        .then(module => module.ErrorPageShellModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
