import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})
export class SigninComponent implements OnInit {
  public loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private auth: RegistrationService
  ) {}

  ngOnInit(){
    this.loginForm = this.fb.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {

      const query = {
        Username: this.loginForm.value.Username,
        Password: this.loginForm.value.Password
      };

      console.log(this.loginForm.value);
      this.auth.signIn(query).subscribe({
        next: (response) => {
          localStorage.setItem('token', response.token);
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
    else {
      console.log("Form us not valid", this.loginForm.errors);
    }
  }
}
