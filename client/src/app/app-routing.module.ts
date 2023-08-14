import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavigationLayoutComponent } from './views/components/layouts/navigation-layout/navigation-layout.component';
import { NoNavLayoutComponent } from './views/components/layouts/no-nav-layout/no-nav-layout.component';
import { SandboxComponent } from './views/pages/sandbox/sandbox.component';


const routes: Routes = 
[
  {
    path: '',
    component: NavigationLayoutComponent,
    children: [
      {
        path: 'overview',
        loadChildren: () => import('./views/pages/overview/overview.module')
        .then(module => module.OverviewModule)
      },
      {
        path: 'internships',
        loadChildren: () => import('./views/pages/internship-hub/internship-hub.module')
        .then(module => module.InternshipHubModule)
      },
      {
        path: 'sandbox',
        component: SandboxComponent
      }
  ]
  },

  {
    path: 'auth',
    component: NoNavLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./views/pages/authentication/authentication.module')
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
