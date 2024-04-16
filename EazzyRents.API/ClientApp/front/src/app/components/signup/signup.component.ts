import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

enum UserRoles {
  Guest = 0, 
  Tenant = 1,
  Landlord = 2,
}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html'
})

export class SignupComponent implements OnInit {
  public signUpForm!: FormGroup;
  selectedRole: UserRoles = UserRoles.Guest; 
  
  constructor(
    private auth: RegistrationService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.signUpForm = this.fb.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      ConfirmPassword: ['', Validators.required],
      UserRole: ['', Validators.required]
    })
  }

  onSubmit() {
    console.log(this.signUpForm.value);
    if(this.signUpForm.valid){

    const command = {
      UserName: this.signUpForm.value.UserName,
      Email: this.signUpForm.value.Email,
      Password: this.signUpForm.value.Password,
      ConfirmPassword: this.signUpForm.value.ConfirmPassword,
      UserRole: this.selectedRole // The selectedRole should be set when a role button is clicked
    };
    
    this.auth.signUp(command)
      .subscribe({
        next: (response) => {
          // Handle the successful response
        },
        error: (error) => {
          // Handle error
          console.error(error);
        }
      });
    }
    else {
      console.error('Form is not valid', this.signUpForm.errors);
    }
    // Handle form submission
  }

  
  selectRole(role: string) {
    this.selectedRole = UserRoles[role as keyof typeof UserRoles]; // Cast the role to the enum type
    this.signUpForm.patchValue({ UserRole: this.selectedRole });
  }
}
