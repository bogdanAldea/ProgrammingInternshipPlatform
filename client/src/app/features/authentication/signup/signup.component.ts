import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Role } from 'src/app/core/accounts/contracts/role';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';
import { SignupRequest } from 'src/app/core/authentication/contracts/signup-request';
import { RoleService } from 'src/app/core/authentication/services/role.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  public constructor(private formBuilder: FormBuilder,
    private router: Router,
    private roleService: RoleService,
    private accountService: AccountService
    ) {}
  
  public ngOnInit(): void {
    this.getAdministratorRole()
      .subscribe((role: Role) => this.administratorRole = role)
  }

  public administratorRole: Role | undefined;

  public signupForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  })


  public submitSignupRequest = () => {
    const request: SignupRequest = this.getAccountSignupDataFromForm();
    this.accountService.signup(request)
    .subscribe({
      next: response => {
        console.log("Signup Completed", response)
      },
      error: error => {
        console.log("Signup failed", error)
      }
    })
  }

  private getAccountSignupDataFromForm = (): SignupRequest => {
    const roles: string[] = [ this.administratorRole!.id]
    const signupRequest: SignupRequest = {
      firstName: this.signupForm.value.firstName!,
      lastName: this.signupForm.value.lastName!,
      email: this.signupForm.value.email!,
      password: this.signupForm.value.password!,
      roles: roles
    }
    return signupRequest;
  }

  private getAdministratorRole = (): Observable<Role> => {
    return this.roleService.getAdministratorRole();
  }

}
