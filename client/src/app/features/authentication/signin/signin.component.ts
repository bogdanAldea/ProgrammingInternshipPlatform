import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SigninRequest } from '../core/interfaces/signin-request';
import { AuthenticationService } from '../core/services/authentication.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent {
  public constructor(private formBuilder: FormBuilder, 
    private authService: AuthenticationService,
    private router: Router) {}

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
        // Token should be stored here
        console.log('Registration successful:', response);
        this.router.navigate(['/user/internships']);
      },
      error: error => {
        // Handle error
        // Api will return an error object
        console.error('Registration failed:', error);
      }
    });
  }
}
