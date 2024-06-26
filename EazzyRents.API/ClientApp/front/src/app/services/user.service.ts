import { Injectable } from '@angular/core';
import { SignupModel } from '../models/signup.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { ProfileModel } from '../models/profile.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl: string = "https://localhost:44379/api/User";
  public user!: SignupModel;


  constructor(private http: HttpClient) { }

  
  getByUserName(userName: string): Observable<SignupModel>{
    return this.http.get<SignupModel>(`${this.apiUrl}/GetByUserName/${userName}`);
  }
  
  getByEmail(email: string): Observable<SignupModel>{
    return this.http.get<SignupModel>(`${this.apiUrl}/GetByEmail/${email}`);
  }

  getByToken(token: string): Observable<ProfileModel>{
    return this.http.get<ProfileModel>(`${this.apiUrl}/GetByToken?token=${token}`);
  }

  checkUniqueUserName(userName: string): Observable<boolean>{
    return this.getByUserName(userName).pipe(
      map(user => !user));
  };

  checkUniqueEmail(email: string): Observable<boolean>{
    return this.getByEmail(email).pipe(
      map(user => !user));
  };

}
