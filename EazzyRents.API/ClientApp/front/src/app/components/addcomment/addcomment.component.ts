import { Component } from '@angular/core';
import { CommentService } from '../../services/comment.service';
import { CommentModel } from '../../models/comment';
import { UserService } from '../../services/user.service';
import { RegistrationService } from '../../services/registration.service';
import { ProfileModel } from '../../models/profile.model';
import { AddCommentModel } from '../../models/addcomment.model';
import { ActivatedRoute, Router } from '@angular/router';
import { SignupModel } from '../../models/signup.model';
import { UserRole } from '../../models/userRole.enum';

@Component({
  selector: 'app-addcomment',
  templateUrl: './addcomment.component.html'
})
export class AddcommentComponent {
  showCommentModal: boolean = false;
  hoveredStar: number | null = null;
  stars: number[] = [1, 2, 3, 4, 5];
  
  comment: CommentModel = {
    reviewMessage: '',
    rating: 0,
    senderName: '',
    createdDate: Date.now.toString()
  };

  addCommentModel: AddCommentModel = {
    SenderId: '',
    ReviewMessage: '',
    RealEstateId: 0,
    Rating: 0
  };

  sender: ProfileModel = {
    id: '',
    userName: '',
    email: '',
    userRole: UserRole.Landlord
  };


  constructor(private commentService: CommentService,
              private userService: UserService,
              private auth: RegistrationService,
              private route: ActivatedRoute,
              private router: Router
  ){}
  
  submitComment() {
    const token = this.auth.getToken();
    console.log(token);



    this.userService.getByToken(token!).subscribe({
      next: (user: ProfileModel) => {
        this.sender = user;

        //this.addCommentModel.SenderId = user.id; error
        this.addCommentModel.Rating = this.comment.rating;
        this.addCommentModel.ReviewMessage = this.comment.reviewMessage;
        
        this.route.params.subscribe(params => {
          this.addCommentModel.RealEstateId = +params['id'];
        })

       this.userService.getByEmail(this.sender.email).subscribe(
          (response: SignupModel) => {
            this.addCommentModel.SenderId = response.id;
            
            this.commentService.addComment(this.addCommentModel).subscribe(
              (response) => {
                alert('Your comment successfully added');
                location.reload();
            })
            
        },
      
      )
        


        this.closeCommentModal();
        },
        error: (error) => {
          console.log(error);
        }
    });
  }

  openCommentModal() {
    this.showCommentModal = true;
  }


hoverStar(star: number) {
  this.hoveredStar = star;
}

unhoverStar() {
  this.hoveredStar = null;
}


  closeCommentModal() {
    this.showCommentModal = false;
    this.comment.reviewMessage = '';
    this.comment.rating = 0;
  }

  setRating(star: number) {
    this.comment.rating = star;
  }


}
