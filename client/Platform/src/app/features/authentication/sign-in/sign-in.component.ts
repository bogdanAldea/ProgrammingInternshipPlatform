import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../core/services/authentication.service';
import { SigninRequest } from '../core/interfaces/signin-request';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
  public constructor(private formBuilder: FormBuilder, 
    private authService: AuthenticationService) {}

  public signInForm: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  })

  public getSignInCredentialsFromForm = () : SigninRequest => {
    const signinRequest: SigninRequest = {
      email: this.signInForm.value.email!,
      password: this.signInForm.value.password!
    };

    return signinRequest;
  }

  public submitSignInCredentials = () => {
    const request: SigninRequest = this.getSignInCredentialsFromForm();
    console.log(request)
    this.authService.submitSignInRequest(request)
    .subscribe({
      next: response => {
        // Handle successful response 
        console.log('Registration successful:', response);

      },
      error: error => {
        // Handle error
        // Api will return an error object
        console.error('Registration failed:', error);
      }
    });
  }
}
