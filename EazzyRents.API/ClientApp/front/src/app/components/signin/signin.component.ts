import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from '../../services/registration.service';
import { Router } from '@angular/router'; 
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html'
})
export class SigninComponent implements OnInit {
  public loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private auth: RegistrationService,
    private router: Router
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
          this.auth.setToken(response.token);
          if(response.token !== null){
            //console.log(response.token);
            alert("Welcome");
            const token = this.auth.getToken();
            this.http.get('/', {
              headers: {
                Authorization: `Bearer ${token}`
              }
            }).subscribe(response => {
              console.log(response);
            })
            
            this.router.navigate(['/']);
          }
          else {
            alert('Wrong username or password');
          }
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
    else {
      console.log("Form is not valid", this.loginForm.errors);
    }
  }
  
  downloadSupportPDF(): void {
    const link = document.createElement('a');
    link.href = 'assets/files/Support.pdf';
    link.download = 'Support_Document.pdf';
    document.body.appendChild(link); // Append to body
    link.click(); // Simulate click to trigger download
    document.body.removeChild(link); // Clean up and remove the element
  }
}
