import { Component, OnInit } from '@angular/core';
import { MenuItem, Menus } from 'src/app/core/menus/menus';

@Component({
  selector: 'app-nav-header',
  templateUrl: './nav-header.component.html',
  styleUrls: ['./nav-header.component.scss']
})
export class NavHeaderComponent implements OnInit {

  public menuItems: MenuItem[] = [];

  
  ngOnInit(): void {
    this.menuItems = Menus.administratorMenuItems;
  }


}
