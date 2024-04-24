import { Component } from '@angular/core';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent {

  constructor(private auth: RegistrationService) {}

  downloadSupportPDF(): void {
    const link = document.createElement('a');
    // Adjust the path according to your directory structure
    link.href = 'assets/files/Support.pdf';
    link.download = 'Support_Document.pdf';
    document.body.appendChild(link); // Append to body
    link.click(); // Simulate click to trigger download
    document.body.removeChild(link); // Clean up and remove the element
  }

  onLogOut(): void {
    this.auth.logout();
    this.auth.removeToken();
  }
}
