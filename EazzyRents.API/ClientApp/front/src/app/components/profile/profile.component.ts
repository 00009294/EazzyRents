import { Component, OnInit } from '@angular/core';
import { ProfileModel } from '../../models/profile.model';
import { UserService } from '../../services/user.service';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {
  user!: ProfileModel;

  constructor(
    private userService: UserService,
    private authService: RegistrationService
  ) {}

  ngOnInit(): void {
      const token = this.authService.getToken();
      
  }
}
