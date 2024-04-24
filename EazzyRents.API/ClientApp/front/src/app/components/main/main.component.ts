import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../../services/registration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html'
})
export class MainComponent implements OnInit {


  constructor(private auth: RegistrationService,
              private router: Router
  ) {}

  ngOnInit(): void {
    const token =  this.auth.getToken();

    if(!token){
      this.router.navigate(['signup']);
    }
  }
}
