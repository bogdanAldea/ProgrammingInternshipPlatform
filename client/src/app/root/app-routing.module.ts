import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrivateLayout } from '../shared/components/layouts/private-layout/private-layout.component';

const routes: Routes = 
[

  {
    path: 'authentication',
    loadChildren: () => import('../authentication/feature/authentication-shell/authentication-shell.module')
    .then(module => module.AuthenticationShellModule)
  },
  
  {
    path: '',
    component: PrivateLayout,
    children: [
      {
        path: 'general-topics',
        loadChildren: () => import('../general-curriculum/features/general-curriculum-shell/general-curriculum-shell.module')
        .then(module => module.GeneralCurriculumShellModule)
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
