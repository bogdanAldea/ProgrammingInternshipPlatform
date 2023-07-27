import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/core/accounts/services/account-service/account.service';
import { SigninRequest } from 'src/app/core/authentication/contracts/signin-request';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent {
  
  public constructor(private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService
    ) {}

    public signinForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    })

    public submitSigninRequest = () => {
      const request: SigninRequest = this.getSignInCredentialsFromForm();
      this.accountService.signin(request)
        .subscribe({
          next: response => {
            localStorage.setItem('access_token', response.token)
            this.router.navigate(['/']);
          },
          error: error => {
            // Handle error
            // Api will return an error object
            console.error('Registration failed:', error);
          }
        })
    }

    private getSignInCredentialsFromForm = (): SigninRequest => {
      const signinRequest: SigninRequest = {
        email: this.signinForm.value.email!,
        password: this.signinForm.value.password!
      };
  
      return signinRequest;
    }

}
