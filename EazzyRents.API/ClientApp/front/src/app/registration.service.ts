import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from './models/register.model';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private baseUrl = 'http://your-backend-url/api'; // Replace with your actual backend URL

  constructor(private http: HttpClient) { }

  register(user: RegisterModel) {
    return this.http.post(`${this.baseUrl}/register`, user);
  }

}
