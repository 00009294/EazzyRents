import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../../services/registration.service';
import { RealEstateService } from '../../services/realestate.service';
import { Router } from '@angular/router';
import { RealEstateModel } from '../../models/realestate.model';
import { UserService } from '../../services/user.service';
import { ProfileModel } from '../../models/profile.model';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {
  estate!: RealEstateModel;
  user!: ProfileModel;
  email: string = '';
  isLandlord: boolean = false;
  constructor(private auth: RegistrationService,
              private realEstateService: RealEstateService,
              private userService: UserService,
              private router: Router
  ) {}

  ngOnInit(): void {
    const token = this.auth.getToken();
    //console.log(token);
    this.userService.getByToken(token!).subscribe({
      next: (user: ProfileModel) => {
        this.email = user.email;
        //console.log(this.email);
        //console.log(user.userRole);
        if(user.userRole === 2){
          console.log(user.userRole === 2)
          this.isLandlord = true;
        }
        else{
          this.isLandlord = false;
        }
        //console.log(this.email);
      }}
    )};

  downloadSupportPDF(): void {
    const link = document.createElement('a');
    // Adjust the path according to your directory structure
    link.href = 'assets/files/Support.pdf';
    link.download = 'Support_Document.pdf';
    document.body.appendChild(link); // Append to body
    link.click(); // Simulate click to trigger download
    document.body.removeChild(link); // Clean up and remove the element
  }

  onSearch(): void {
    this.realEstateService.getRealEstatesByEmail(this.email);
    this.router.navigate(['/dashboard',this.email]);
    //console.log(this.router.navigate(['/dashboard',this.email]));

  }

  onLogOut(): void {
    this.auth.logout();
    this.auth.removeToken();
  }

  goToChat(){
    console.log('goToChat');
    this.router.navigate(['chat']);
  }
}
