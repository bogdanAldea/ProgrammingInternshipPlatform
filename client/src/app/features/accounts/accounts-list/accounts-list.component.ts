import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.scss']
})
export class AccountsListComponent implements OnInit {
  public accounts$: Observable<AccountWithRoles[]> | undefined;

  public constructor(private accountService: AccountService) {}
  
  public ngOnInit(): void 
  {
    this.accounts$ = this.getAllAccountAtOrganisation();
    this.accounts$.subscribe(x => console.log(x))

  }

  private getAllAccountAtOrganisation = () => {
    return this.accountService.getAllAccountsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
  }

}
