import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipDetailPage } from './internship-detail.page.component';
import { SetupComponent } from '../internship-settings/setup/setup.component';
import { TrainersComponent } from '../internship-settings/trainers/trainers.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipDetailPage,
    loadChildren: () => import('../internship-settings/internship-settings.module')
    .then(m => m.InternshipSettingsModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipDetailRoutingModule { }
