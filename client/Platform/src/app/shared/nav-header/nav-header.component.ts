import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuItem, Menus } from 'src/app/core/menus/menus';

@Component({
  selector: 'app-nav-header',
  templateUrl: './nav-header.component.html',
  styleUrls: ['./nav-header.component.scss']
})
export class NavHeaderComponent implements OnInit {

  public menuItems: MenuItem[] = [];

  constructor(private route: ActivatedRoute, private router: Router){}

  ngOnInit(): void {
    this.menuItems = Menus.administratorMenuItems;
  }


}
