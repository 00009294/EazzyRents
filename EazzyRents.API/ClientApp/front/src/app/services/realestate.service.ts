import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RealEstateModel } from '../models/realestate.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RealestateService {
  private apiUrl = 'https://localhost:44379/api/RealEstate'; // Update with your backend API URL

  constructor(private http: HttpClient) { }

  getRealEstates(): Observable<RealEstateModel[]> {
    return this.http.get<RealEstateModel[]>(`${this.apiUrl}`);
  }
}
