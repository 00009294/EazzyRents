import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignupModel } from '../models/signup.model';
import { SigninModel } from '../models/signin.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private baseUrl = 'https://localhost:44379/api/Authentication'; // Replace with your actual backend URL

  constructor(private http: HttpClient) { }

  signUp(userObj: SignupModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/signup`, userObj);
  }

  signIn(loginObj : SigninModel) : Observable<any> {
    return this.http.post(`${this.baseUrl}/signin`, loginObj)
  }

  getToken(): string | null {
    return localStorage.getItem('token'); // Retrieve token from local storage
  }

  setToken(token: string) {
    localStorage.setItem('token', token); // Save token to local storage
  }

  removeToken() {
    localStorage.removeItem('token'); // Remove token from local storage
  }

}
