import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegistrationService } from '../registration.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

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
}
