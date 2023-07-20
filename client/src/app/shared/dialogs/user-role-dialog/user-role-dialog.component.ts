import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { DeltaRolesRequest } from 'src/app/core/accounts/contracts/DeltaRolesRequest';
import { AccountWithRoles } from 'src/app/core/accounts/contracts/account-with-roles';
import { Role } from 'src/app/core/accounts/contracts/role';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';
import { RolesService } from 'src/app/core/accounts/services/roles-service/roles.service';

@Component({
  selector: 'app-user-role-dialog',
  templateUrl: './user-role-dialog.component.html',
  styleUrls: ['./user-role-dialog.component.scss']
})
export class UserRoleDialogComponent implements OnInit{
  @Output() userRolesChangedEvent: EventEmitter<DeltaRolesRequest> = new EventEmitter<DeltaRolesRequest>;
  public userAccount$: Observable<AccountWithRoles> | undefined;
  public roles$: Observable<Role[]> | undefined;
  public userRoles: Role[] | undefined;
  public deltaRoleChange: DeltaRolesRequest = { rolesToAdd: [], rolesToRemoved: [] }
  
  public constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private accountService: AccountService,
    private roleService: RolesService,
  ) 
  {
    this.userAccount$ = data.selectedUserAccount,
    this.roles$ = data.systemRoles
  }
  
  public ngOnInit(): void {
    this.userAccount$?.subscribe(account => {
      this.userRoles = account.roles;
    })

  }

  public isRoleAssignedToUser = (role: Role) => {
    const roleIds = this.userRoles?.map(role => role.id);
    return roleIds?.includes(role.id);
  }

  public onRoleAssignment = (role: Role, isAssigned: boolean): void => {
    const roleIds = this.userRoles?.map(role => role.id);
    if (isAssigned) {
      if (!roleIds!.includes(role.id)) {
        this.deltaRoleChange.rolesToAdd.push(role)
      }
    }
    else {
      const indexOfRoleToRemove = roleIds!.indexOf(role.id);
      if (indexOfRoleToRemove !== -1) {
        this.deltaRoleChange.rolesToRemoved.push(role)
      }
    }
  }

  public onRoleChangedSubmit = (): void => {
    this.userRolesChangedEvent.emit(this.deltaRoleChange);
  }

  private getUserAccount = (userId: string): Observable<AccountWithRoles> => {
    return this.accountService.getUserAccount(userId);
  }

  private getRoles = (): Observable<Role[]> => {
    return this.roleService.getAllRoles();
  }
}
