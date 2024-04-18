import { Injectable } from '@angular/core';
import { CommentModel } from '../models/comment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private baseUrl = "https://localhost:44379/api/RealEstateRatingAndReview";
  comment: CommentModel | undefined;
  comments: CommentModel[] = [];
  constructor(private http: HttpClient) { }

  getComments(id: number): Observable<CommentModel[]> {
    return this.http.get<CommentModel[]>(`${this.baseUrl}/?id=${id}`);
  }
}
