import { Component, OnInit, Input,  AfterViewInit, ViewChild, ElementRef, inject } from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { RealEstateModel } from '../../models/realestate.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Address } from '../../models/address';
import { CommentModel } from '../../models/comment';
import { CommentService } from './../../services/comment.service';
import { ChatService } from '../../services/chat.service';
import { RegistrationService } from '../../services/registration.service';
import { UserService } from '../../services/user.service';
import { ProfileModel } from '../../models/profile.model';

@Component({
  selector: 'app-realestate-profile',
  templateUrl: './realestate-profile.component.html'
})

export class RealestateProfileComponent implements OnInit{
  baseUrl: any = "https://localhost:44379/";
  @Input() realEstate: RealEstateModel | null = null;

  comments: CommentModel[] = [];
  @Input() comment!: CommentModel;
  selectedImageUrl: string = '';
  id!: number;


  userName: string = '';
  room: string = '';

  

constructor(private realEstateService: RealEstateService, 
  private commentService: CommentService,
  private route: ActivatedRoute,
  private router: Router,
  private auth: RegistrationService,
  private userService: UserService,
  private chatService: ChatService
      ){}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.room = params['id'];
    })
    this.getRealEstate();
    this.commentService.getComments(this.id).subscribe(
      (data: CommentModel[]) => {
        this.comments = data;
      }
    )
  }
 
  getRealEstate(): void{
    if(this.id){
      this.realEstateService.getRealEstateById(this.id).subscribe(
        data  => {
          this.realEstate = data;
          if (this.realEstate.imageUrls.length > 0) {
            this.selectedImageUrl = this.realEstate.imageUrls[0];
          }
        },
        error => {
          console.error('Real estate not found', error);
        }
      );
    }
    else {
      console.error('ID not provided');
    }
  }

  public getAddressString(value: number): string {
    switch(value) {
      case Address.Tashkent:
        return 'Tashkent';
      case Address.Samarkand:
        return 'Samarkand';
      case Address.Bukhara:
        return 'Bukhara';
      default:
        return 'Unknown Address';
    }
  }

  selectImage(imageUrl: string): void {
    this.selectedImageUrl = imageUrl;
  }

  goToChat(){
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.router.navigate([`chat/${this.id}`]);
    })
  }

}
