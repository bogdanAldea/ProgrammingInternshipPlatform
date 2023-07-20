import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { DeltaRolesRequest } from 'src/app/core/accounts/contracts/DeltaRolesRequest';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';
import { MemberAccountRegistration } from 'src/app/core/accounts/contracts/member-account-registration';
import { Role } from 'src/app/core/accounts/contracts/role';
import { UserData } from 'src/app/core/accounts/models/user-data';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';
import { RolesService } from 'src/app/core/accounts/services/roles-service/roles.service';
import { AddUserDialogComponent } from 'src/app/shared/dialogs/add-user-dialog/add-user-dialog.component';
import { UserRoleDialogComponent } from 'src/app/shared/dialogs/user-role-dialog/user-role-dialog.component';

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.scss']
})
export class AccountsListComponent implements OnInit {
  public accounts$: Observable<AccountWithRoles[]> | undefined;
  public roles$: Observable<Role[]> | undefined;

  public constructor(
    private accountService: AccountService, 
    private roleService: RolesService,
    public dialog: MatDialog
  ) {}
  
  public ngOnInit(): void 
  {
    this.roles$ = this.roleService.getAllRoles();
    this.accounts$ = this.getAllAccountAtOrganisation();
  }

  private refresh = () => {
    this.accounts$ = this.getAllAccountAtOrganisation();
  }

  private getAllAccountAtOrganisation = () => {
    return this.accountService.getAllAccountsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
  }

  public changeUserRoles = (userData: UserData) => {

    const selectedUserAccount$: Observable<AccountWithRoles> = this.accountService.getUserAccount(userData.userId);
    const systemRoles$: Observable<Role[]> = this.roleService.getAllRoles();

    const dialogRef = this.dialog.open(UserRoleDialogComponent, {
      data: {
        selectedUserAccount: selectedUserAccount$,
        systemRoles: systemRoles$ 
      },
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

  public addNewUser = () => {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.position = {right: '0'}
    dialogConfig.height = '100%'
    dialogConfig.width = '600px';
    dialogConfig.data = {
      roles: this.roles$,
      companyId: 'b4f75fed-37bf-40fc-a8b3-f071b41a3fc1'
    }
    const dialogRef = this.dialog.open(AddUserDialogComponent, dialogConfig)

    dialogRef.componentInstance.newAccountFormFilledEvent.subscribe((newAccount: MemberAccountRegistration) => {
      this.accountService.addNewUserAccount(newAccount)
      .subscribe(() => this.refresh());
      dialogRef.close();
    })

  } 

}
