import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from '../models/message.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private baseUrl = "https://localhost:44379/api/Chat";
  messages: Message[] = [];

  constructor(private http: HttpClient) {}

  getMessages(id: number): Observable<Message[]> {
    return this.http.get<Message[]>(`${this.baseUrl}?roomId=${id}`);
  }

  sendMessage(message: Message): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}`, message);
  }
}