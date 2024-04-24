import { Component, OnInit } from '@angular/core';
import { FormBuilder, AbstractControl, ValidationErrors, ValidatorFn, NgForm } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SignupModel } from '../../models/signup.model';
import { Router } from '@angular/router';
import { timer, Observable } from 'rxjs';
import { tap, switchMap } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { take } from 'rxjs/operators';
import { UserService } from '../../services/user.service';


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
  private count: number = 0;
  public signUpForm!: FormGroup;
  public SignUp!: SignupModel;
  selectedRole: UserRoles | null = null; 
  
  constructor(
    private router: Router,
    private auth: RegistrationService,
    private userService: UserService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {

    this.signUpForm = this.fb.group({
      UserName: ['', [Validators.required, Validators.minLength(5)]],
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [
        Validators.required,
        Validators.minLength(7),
        SignupComponent.requireDigit(),
        SignupComponent.requireNonAlphanumeric(),
        SignupComponent.requireUppercase(),
        SignupComponent.requireLowercase(),
      ]],
      ConfirmPassword: ['', [Validators.required]],
      UserRole: ['', Validators.required]
    }, {
      validator: this.mustMatch('Password', 'ConfirmPassword')
    });
  }

  onSubmit() {

    let usernameUnique = true;
    let emailUnique = true;

    if(this.signUpForm.valid){
      const signupData: SignupModel = this.signUpForm.value;
      console.log(signupData);

      this.userService.checkUniqueUserName(signupData.UserName).subscribe(
        isUnique => {
          if(!isUnique){
            usernameUnique = false;
            alert('Username is already taken');
          }
      
        this.userService.checkUniqueEmail(signupData.Email).subscribe(
          isUnique => {
          if(!isUnique){
            emailUnique  = false;
            alert('Email is already taken');
          }

      if (usernameUnique && emailUnique) {
        console.log(this.count);
        this.auth.signUp(signupData).pipe(tap(() => { }),
        switchMap(() => timer(2000))).subscribe({
          next: (response) => {
            alert('Successfully registered');
            this.router.navigate(['/signin']);
          },
          error: (error) => {
            console.error(error);
          }
        });
      }
    });
  });
}}


  selectRole(role: string) {
    this.selectedRole = UserRoles[role as keyof typeof UserRoles];
    this.signUpForm.patchValue({ UserRole: this.selectedRole });
  }
  
  getValidationMessage(field: string): string | null {
    const control = this.signUpForm.get(field);
  
    if (control && control.touched && control.errors) {
    const errors = control.errors;
    if (errors['required']) {
      return 'This field is required.';
    }
    if ('minlength' in errors) {
      return `This field must be at least ${errors['minlength'].requiredLength} characters.`;
    }
    if (errors['email']) {
      return 'This field must be a valid email.';
    }
    if (errors['mustMatch']) {
      return 'Passwords must match.';
    }
    
  }
  
  return null; // If no errors, return null
}

// Custom validator to check if two form fields match
mustMatch(controlName: string, matchingControlName: string) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    const matchingControl = formGroup.controls[matchingControlName];

    if (matchingControl.errors && !matchingControl.errors['mustMatch']) {
      return;
    }
    
    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({ mustMatch: true });
    } else {
      matchingControl.setErrors(null);
    }
  };
}

static requireDigit(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return /\d/.test(control.value) ? null : { requireDigit: true };
  };
}

static requireNonAlphanumeric(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return /\W/.test(control.value) ? null : { requireNonAlphanumeric: true };
  };
}

static requireUppercase(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return /[A-Z]/.test(control.value) ? null : { requireUppercase: true };
  };
}

static requireLowercase(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return /[a-z]/.test(control.value) ? null : { requireLowercase: true };
  };
}
}