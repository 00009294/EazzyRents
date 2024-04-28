import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RealEstateModel } from '../models/realestate.model';
import { AddRealEstateModel } from '../models/addrealestate.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RealEstateService {
  private apiUrl = 'https://localhost:44379/api/RealEstate'; // Update with your backend API URL
  // https://localhost:44379/api/RealEstate?Description=NRG&Price=99800&PhoneNumber=997000101&Email=fayzullaev.javlonbek.d%40gmail.com&Longitude=69.245443&Latitude=41.339668&About=This%20is%20about%20page&Address=2&RealEstateStatus=0
  realEstate: RealEstateModel | undefined;
  realEstates: RealEstateModel[] = [];
  private realEstateSubject = new BehaviorSubject<RealEstateModel[]>([]);
  realEstates$ = this.realEstateSubject.asObservable();
  
  constructor(private http: HttpClient) { }

  createRealEstate(estate: AddRealEstateModel): Observable<AddRealEstateModel> {
    let decodedEmail = decodeURIComponent(estate.Email);
    let decodedString = decodeURIComponent(estate.About.replace(/\+/g, ' '));
    console.log("Sevice: " + estate.ImageDataList);
    console.log("Service2: " + estate);
    return this.http.post<AddRealEstateModel>(`${this.apiUrl}?Description=${estate.Description}&Price=${estate.Price}&PhoneNumber=${estate.PhoneNumber}&Email=${decodedEmail}&Longitude=${estate.Longitude}&Latitude=${estate.Latitude}&About=${decodedString}&Address=${estate.Address}&RealEstateStatus=${estate.RealEstateStatus}`, estate);
    //return this.http.post<AddRealEstateModel>(`${this.apiUrl}`, estate);
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
