import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../../services/user.service';
import { RegistrationService } from '../../services/registration.service';
import { ProfileModel } from './../../models/profile.model';
import { UserRole } from '../../models/userRole.enum';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {
  
  user: ProfileModel  = {
    id: '',
    email: '',
    userName: '',
    userRole: ''
  };


  constructor(
    private userService: UserService,
    private authService: RegistrationService
  ) {}

  ngOnInit(): void {
      const token = this.authService.getToken();
      this.userService.getByToken(token!).subscribe({
        next: (profile: ProfileModel) => {
          this.user = profile;
        },
        error: (error) =>{
          console.log(error);
        }
        }
      );
  }

  public getUserRoleString(value: number): string {
    switch(value) {
      case UserRole.Guest:
        return 'Guest';
      case UserRole.Landlord:
        return 'Landlord';
      case UserRole.Tenant:
        return 'Tenant';
      default:
        return 'Unknown User';
    }
  }
}
