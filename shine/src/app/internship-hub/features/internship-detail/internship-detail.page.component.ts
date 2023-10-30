import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NodeData } from 'src/app/shared/components/navigations/node/types/nodeData';
import { MenuNodeConfiguration } from 'src/app/shared/configurations/menu-nodes/menuNodeConfiguration';

@Component({
  selector: 'internship-detail.page',
  templateUrl: './internship-detail.page.component.html',
  styleUrls: ['./internship-detail.page.component.scss']
})
export class InternshipDetailPage {
  public settingsNodes: NodeData[] = MenuNodeConfiguration.getSettingsForSelectedInternship();
}
