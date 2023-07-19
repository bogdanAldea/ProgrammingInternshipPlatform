import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';
import { UserData } from 'src/app/core/accounts/models/user-data';

@Component({
  selector: 'app-accounts-table',
  templateUrl: './accounts-table.component.html',
  styleUrls: ['./accounts-table.component.scss']
})
export class AccountsTableComponent {
  @Input() accounts$: Observable<AccountWithRoles[]> | undefined;
  @Output() onUserSelectedEvent: EventEmitter<any> = new EventEmitter<any>();

  public onUserSelected(userId: string, identityId: string) {
    const userData: UserData = {userId: userId, identityId: identityId}
    return this.onUserSelectedEvent.emit(userData);
  }
}
