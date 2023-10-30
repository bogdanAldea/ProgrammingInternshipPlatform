import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneralCurriculumListPage } from './general-curriculum-list.component';

const routes: Routes = [
  {
    path: '',
    component: GeneralCurriculumListPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneralCurriculumListRoutingModule { }
