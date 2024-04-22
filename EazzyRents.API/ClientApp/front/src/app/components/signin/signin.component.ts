import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html'
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
  
  downloadSupportPDF(): void {
    const link = document.createElement('a');
    // Adjust the path according to your directory structure
    link.href = 'assets/files/Support.pdf';
    link.download = 'Support_Document.pdf';
    document.body.appendChild(link); // Append to body
    link.click(); // Simulate click to trigger download
    document.body.removeChild(link); // Clean up and remove the element
  }
}
