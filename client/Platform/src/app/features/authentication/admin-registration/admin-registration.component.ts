import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { SignupRequest } from '../core/interfaces/signup-request';
import { AuthenticationService } from '../core/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-registration',
  templateUrl: './admin-registration.component.html',
  styleUrls: ['./admin-registration.component.scss']
})
export class AdminRegistrationComponent implements OnInit {
  
  public constructor(private formBuilder: FormBuilder, 
    private authService: AuthenticationService,
    private router: Router) {}
  
  public ngOnInit(): void {
  }

  public registrationForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  })

  public getSignupValuesFromForm = () : SignupRequest => {
    const signupRequest: SignupRequest = {
      firstName: this.registrationForm.value.firstName!,
      lastName: this.registrationForm.value.lastName!,
      email: this.registrationForm.value.email!,
      password: this.registrationForm.value.password!
    }

    return signupRequest;
  }

  public submitSignupForm = () => {
    const request: SignupRequest = this.getSignupValuesFromForm();
    this.authService.submitSignUpRequest(request)
    .subscribe({
      next: response => {
        // Handle successful response 
        // Should redirect to login page
        console.log('Registration successful:', response);
        this.router.navigate(['/signin']);
      },
      error: error => {
        // Handle error
        // Api will return an error object
        console.error('Registration failed:', error);
      }
    });
  }
}
