import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';

@Component({
  selector: 'app-accounts-table',
  templateUrl: './accounts-table.component.html',
  styleUrls: ['./accounts-table.component.scss']
})
export class AccountsTableComponent {
  @Input() accounts$: Observable<AccountWithRoles[]> | undefined;

}
