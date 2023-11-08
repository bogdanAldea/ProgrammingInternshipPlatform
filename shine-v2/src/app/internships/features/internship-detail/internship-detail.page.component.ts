import { Component } from '@angular/core';
import { InternshipOptionsRouteNodes } from 'src/app/shared/helpers/routing/applicationRoutes';
import { RouteNode } from 'src/app/shared/helpers/routing/node';

@Component({
  selector: 's-internship-detail.page',
  templateUrl: './internship-detail.page.component.html',
  styleUrls: ['./internship-detail.page.component.scss']
})
export class InternshipDetailPage {
  public options: ReadonlyArray<RouteNode> = InternshipOptionsRouteNodes.Administrator;
}
