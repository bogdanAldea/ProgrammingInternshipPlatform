import { Component, OnInit } from '@angular/core';
import { MenuNodes } from 'src/app/shared/configurations/menuNodes';
import { Node } from '../../navigations/link-node/link-node.component';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'sidebar-layout',
  templateUrl: './sidebar-layout.component.html',
  styleUrls: ['./sidebar-layout.component.scss']
})
export class SidebarLayout {
  public nodes: ReadonlyArray<Node> = MenuNodes.ForAdministratorMuted;

}
