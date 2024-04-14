import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegistrationService } from '../registration.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  selectedRole: string = ''; 
  signupForm = new FormGroup({
    // ... other form controls like 'fullName', 'email', etc.
    role: new FormControl('', [Validators.required])
  });
  constructor(private registrationService: RegistrationService) { }

  onRegister(form: NgForm) {
    if (form.invalid) {
      return;
    }
    this.registrationService.register(form.value).subscribe(
      response => {
        console.log('Registration successful', response);
      },
      error => {
        console.error('Registration failed', error);
      }
    );
  }

  onSubmit() {
    console.log(this.signupForm.value);
    // Handle form submission
  }

  selectRole(role: string) {
    this.selectedRole = role;
  }

}
