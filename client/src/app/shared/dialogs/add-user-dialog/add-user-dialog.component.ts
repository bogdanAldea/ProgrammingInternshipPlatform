import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { MemberAccountRegistration } from 'src/app/core/accounts/contracts/member-account-registration';
import { Role } from 'src/app/core/accounts/contracts/role';

@Component({
  selector: 'app-add-user-dialog',
  templateUrl: './add-user-dialog.component.html',
  styleUrls: ['./add-user-dialog.component.scss']
})
export class AddUserDialogComponent implements OnInit {
  
  public constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
    ) 
  {
    this.roles$ = data.systemRoles
  }

  public ngOnInit(): void {
    this.roles$ = this.data.roles
  }

  @Output() newAccountFormFilledEvent: EventEmitter<MemberAccountRegistration> = new EventEmitter<MemberAccountRegistration>;
  public roles$: Observable<Role[]> | undefined;

  public newUserForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    roles: [ [], [Validators.required]],
  })

  public getNewUserData = (): void => {
    const newMemberRequest: MemberAccountRegistration = {
      firstName: this.newUserForm.value.firstName!,
      lastName: this.newUserForm.value.lastName!,
      email: this.newUserForm.value.email!,
      companyId: this.data.companyId,
      roles: this.newUserForm.value.roles!
    }
    this.newAccountFormFilledEvent.emit(newMemberRequest);
  }

}
