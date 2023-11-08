import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipsListComponent } from './internships-list.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntershipsListRoutingModule { }
