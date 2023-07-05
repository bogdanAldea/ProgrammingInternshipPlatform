import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutWithNavigationComponent } from './layouts/layout-with-navigation/layout-with-navigation.component';
import { LayoutWithoutNavigationComponent } from './layouts/layout-without-navigation/layout-without-navigation.component';
import { StackedNavigationComponent } from './navigations/stacked-navigation/stacked-navigation.component';
import { RouterModule } from '@angular/router';
import { InternshipsTableComponent } from './tables/internships-table/internships-table.component';
import { ButtonRectSmallComponent } from './buttons/button-rect-small/button-rect-small.component';
import { InternshipOptionCardComponent } from './cards/internship-option-card/internship-option-card.component';
import { BreadcrumbComponent } from './navigations/breadcrumb/breadcrumb.component';
import { TitleComponent } from './typography/title/title.component';
import { DescriptionComponent } from './typography/description/description.component';



@NgModule({
  declarations: [
    LayoutWithNavigationComponent,
    LayoutWithoutNavigationComponent,
    StackedNavigationComponent,
    InternshipsTableComponent,
    ButtonRectSmallComponent,
    InternshipOptionCardComponent,
    BreadcrumbComponent,
    TitleComponent,
    DescriptionComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    InternshipsTableComponent,
    ButtonRectSmallComponent,
    InternshipOptionCardComponent,
    BreadcrumbComponent,
    TitleComponent,
    DescriptionComponent
  ]
})
export class SharedModule { }
