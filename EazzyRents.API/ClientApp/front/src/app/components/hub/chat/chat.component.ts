import { Component, OnInit } from '@angular/core';
import { Message } from '../../../models/message.model';
import { ChatService } from '../../../services/chat.service';
import { UserRole } from '../../../models/userRole.enum';
import { ActivatedRoute } from '@angular/router';
import { RegistrationService } from '../../../services/registration.service';
import { UserService } from '../../../services/user.service';
import { ProfileModel } from '../../../models/profile.model';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
})
export class ChatComponent implements OnInit {
  messages: Message[] = [];
  newMessage: string = '';
  roomId!: number;
  isLandlord!: boolean;
  userRole!: UserRole;

  constructor(private chatService: ChatService,
              private route: ActivatedRoute,
              private auth: RegistrationService,
              private userService: UserService
  ) {}

  ngOnInit(): void {
    
    this.loadMessages();
  }

  loadMessages(): void {
    this.route.params.subscribe(params => {
      this.roomId = params['id'];
    })
    this.chatService.getMessages(this.roomId).subscribe(
      (response: Message[]) => {
        this.messages = response;
      },
      (error: any) => {
        console.error('Error loading messages:', error);
      }
    );
  }

  // try to send message by running swagger and ng serve both


  sendMessage(): void {
    const token = this.auth.getToken();
    this.userService.getByToken(token!).subscribe({
      next: (user: ProfileModel) => {
        this.isLandlord = false;
        this.userRole = user.userRole;
        

        console.log('UserRole1 is ' + this.userRole);
        if (this.newMessage.trim() !== '') {
          const message: Message = {
            content: this.newMessage,
            realEstateId: this.roomId,
            timestamp: Date.now(),
            userRole: this.userRole // Or 'Landlord', depending on the role
            
      };

      
      this.chatService.sendMessage(message).subscribe(
        (response: any) => {
          // Handle successful sending if needed
          // Assuming the message is immediately displayed, add it to the local messages array
          this.messages.push(message);
          location.reload();
          this.newMessage = ''; // Clear the input field after sending the message
        },
        (error: any) => {
          console.error('Error sending message:', error);
          // Handle error if needed
        }
      );
    }
  }
})
  }
}
