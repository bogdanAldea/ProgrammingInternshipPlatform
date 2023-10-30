import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutWithNavigation } from '../shared/components/layout/layout-with-navigation/layout-with-navigation/layout-with-navigation.component';

const routes: Routes = [
  {
    path: 'authentication',
    loadChildren: () => import('../authentication/feature/authentication-shell/authentication-shell.module')
    .then(module => module.AuthenticationShellModule)
  },

  {
    path: '',
    component: LayoutWithNavigation,
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('../dashboard/features/dashboard-shell/dashboard-shell.module')
        .then(module => module.DashboardShellModule)
      },

      {
        path: 'internships',
        loadChildren: () => import('../internship-hub/features/internship-hub-shell/internship-hub-shell.module')
        .then(module => module.InternshipHubShellModule)
      },

      {
        path: 'general-curriculum',
        loadChildren: () => import('../general-curriculum/features/general-curriculum-shell/general-curriculum-shell.module')
        .then(module => module.GeneralCurriculumShellModule)
      }
    ]
  },

  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
