import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupRequest } from '../core/interfaces/signup-request';
import { AuthenticationService } from '../core/services/authentication.service';
import { AdminRole } from '../core/interfaces/admin-role';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  private adminRole: AdminRole | undefined;
  
  public constructor(private formBuilder: FormBuilder,
    private authService: AuthenticationService,
    private router: Router) {}
  
  
    public ngOnInit(): void {
      this.authService.getAdminRole()
      .subscribe((response: AdminRole) => {
        this.adminRole = response;
        console.log(response)
      })
  }

    public registrationForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    })

    public getSignupValuesFromForm = () : SignupRequest => {
      const roles: string[] = [this.adminRole!.id];
      const signupRequest: SignupRequest = {
        firstName: this.registrationForm.value.firstName!,
        lastName: this.registrationForm.value.lastName!,
        email: this.registrationForm.value.email!,
        password: this.registrationForm.value.password!,
        roles: roles
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
          this.router.navigate(['/auth/signin']);
        },
        error: error => {
          // Handle error
          // Api will return an error object
          console.error('Registration failed:', error);
        }
      });
    }
}
