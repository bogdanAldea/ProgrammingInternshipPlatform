import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, IsActiveMatchOptions, Router } from '@angular/router';

@Component({
  selector: 's-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  @Input() nodes: ReadonlyArray<any> | undefined;
  public isActive: boolean = false;

  public constructor(private readonly router: Router) {}


  public isActiveRoute = (route: string): boolean => {
    const options: IsActiveMatchOptions = {paths: 'exact', queryParams: 'exact', fragment: 'ignored', matrixParams: 'ignored'}
    return this.router.isActive(route, options)
  };
}
