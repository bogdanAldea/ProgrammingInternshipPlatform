import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavigationLayoutComponent } from './shared-modules/layouts/navigation-layout/navigation-layout.component';

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
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
