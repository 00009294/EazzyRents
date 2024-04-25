import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RealEstateModel } from '../models/realestate.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RealEstateService {
  private apiUrl = 'https://localhost:44379/api/RealEstate'; // Update with your backend API URL
  realEstate: RealEstateModel | undefined;
  realEstates: RealEstateModel[] = [];
  private realEstateSubject = new BehaviorSubject<RealEstateModel[]>([]);
  realEstates$ = this.realEstateSubject.asObservable();
  
  constructor(private http: HttpClient) { }

  createRealEstate(estate: RealEstateModel) {
    this.http.post<RealEstateModel>(`${this.apiUrl}`, estate);
  }

  getRealEstatesByEmail(email: string): Observable<RealEstateModel[]>{
    var encodedEmail = decodeURIComponent(email);
    return this.http.get<RealEstateModel[]>(`${this.apiUrl}/GetByEmail/${encodedEmail}`);
  }

  getRealEstates(): void {
    this.http.get<RealEstateModel[]>(`${this.apiUrl}`)
    .subscribe( data => {
      this.realEstateSubject.next(data);
    },
    error => {
      console.log('Error while fetching all real estates', error);
    }
  )}

  getRealEstateById(id: number): Observable<RealEstateModel>{
    return this.http.get<RealEstateModel>(`${this.apiUrl}/GetById/${id}`)
  }

  getRealEstatesByName(name: string): void {
    if(name.trim() === ''){
      this.getRealEstates();
    }
    else {
      this.http.get<RealEstateModel[]>(`${this.apiUrl}/GetByName/${name}`)
      .subscribe( data => {
        this.realEstateSubject.next(data);
      },
      error => {
        console.log('Error fetching real estate', error);
      }
    );
  }}

  getRealEstateByPrice(fromPrice: number, toPrice: number) : void {
    this.http.get<RealEstateModel[]>(`${this.apiUrl}/GetByPrice?fromPrice=${fromPrice}&toPrice=${toPrice}`)
    .subscribe(data => {
      this.realEstateSubject.next(data);
    },
  error => {
    console.log('Error fetching real estate', error);
    });
  }

  getRealEstateByAddress(num: number): void {
    this.http.get<RealEstateModel[]>(`${this.apiUrl}/GetByAddress/${num}`).
    subscribe(data => {
      this.realEstateSubject.next(data);
    });
  }

  deleteById(id: number): void{
    this.http.delete(`${this.apiUrl}/?id=${id}`).subscribe();
  }
}
