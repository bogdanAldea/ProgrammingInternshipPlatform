import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { DeltaRolesRequest } from 'src/app/core/accounts/contracts/DeltaRolesRequest';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';
import { Role } from 'src/app/core/accounts/contracts/role';
import { UserData } from 'src/app/core/accounts/models/user-data';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';
import { UserRoleDialogComponent } from 'src/app/shared/dialogs/user-role-dialog/user-role-dialog.component';

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.scss']
})
export class AccountsListComponent implements OnInit {
  public accounts$: Observable<AccountWithRoles[]> | undefined;

  public constructor(
    private accountService: AccountService, 
    public dialog: MatDialog
  ) {}
  
  public ngOnInit(): void 
  {
    this.refresh();
  }

  private refresh = () => {
    this.accounts$ = this.getAllAccountAtOrganisation();
  }

  private getAllAccountAtOrganisation = () => {
    return this.accountService.getAllAccountsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
  }

  public selectUserFromTable = (userData: UserData) => {
    const dialogRef = this.dialog.open(UserRoleDialogComponent, {
      data: userData,
      width: '600px',
    })

    dialogRef.componentInstance.userRolesChangedEvent.subscribe((rolesRequest: DeltaRolesRequest) => {
      const rolesToAddAreSet: boolean = rolesRequest.rolesToAdd.length !== 0;
      const rolesToRemoveAreSet: boolean = rolesRequest.rolesToRemoved.length !== 0;

      if (rolesToAddAreSet) {
        this.accountService.assignRolesToUserAccount(userData.identityId, rolesRequest.rolesToAdd)
        .subscribe(() => this.refresh());
      };
      
      if(rolesToRemoveAreSet) {
        this.accountService.removeRolesFromUserAccount(userData.identityId, rolesRequest.rolesToRemoved)
        .subscribe(() => this.refresh());
      }

      dialogRef.close()
    })
  }

}
