import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtTokenHelper } from 'src/app/shared/helpers/access/jwtTokenHelper';
import { ApplicationRouteNodes } from 'src/app/shared/helpers/routing/applicationRoutes';
import { RouteNode } from 'src/app/shared/helpers/routing/node';
import { Account, AccountsService } from 'src/app/shared/services/accounts.service';

@Component({
  selector: 's-sidebar-layout',
  templateUrl: './sidebar-layout.component.html',
  styleUrls: ['./sidebar-layout.component.scss']
})
export class SidebarLayoutComponent implements OnInit {
  public readonly nodes: ReadonlyArray<RouteNode> = ApplicationRouteNodes.Administrator;
  private readonly decoder = new JwtTokenHelper()
  
  public account$!: Observable<Account>;

  public constructor(private readonly service: AccountsService) {}

  public ngOnInit(): void {
    const accountId = this.decoder.getAccountIdentifier();
    this.account$ = this.service.getAccountById(accountId);
  }
}
