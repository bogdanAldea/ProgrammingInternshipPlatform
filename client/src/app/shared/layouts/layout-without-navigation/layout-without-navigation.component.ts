import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupRequest } from 'src/app/features/authentication/core/interfaces/signup-request';
import { AuthenticationService } from 'src/app/features/authentication/core/services/authentication.service';

@Component({
  selector: 'app-layout-without-navigation',
  templateUrl: './layout-without-navigation.component.html',
  styleUrls: ['./layout-without-navigation.component.scss']
})
export class LayoutWithoutNavigationComponent {
  
}
