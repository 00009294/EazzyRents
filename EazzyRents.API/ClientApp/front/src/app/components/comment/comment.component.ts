import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommentModel } from '../../models/comment';
import { CommentService } from '../../services/comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html'
})
export class CommentComponent{
  comments: CommentModel[] = [];
  @Input() comment: CommentModel | undefined;

  constructor(private commentService: CommentService) {}

  getComments(id: number) {
    this.commentService.getComments(id);
  }
}


