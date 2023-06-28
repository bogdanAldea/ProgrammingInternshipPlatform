import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContextLayoutComponent } from './shared/layouts/context-layout/context-layout.component';

const routes: Routes = [
  {
    path: "",
    component: ContextLayoutComponent,
    children: 
    [
      {
        path: 'internships',
        loadChildren: () => import('../app/features/internship-management/internship-routing/internship-routing.module')
                                .then(module => module.InternshipRoutingModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
