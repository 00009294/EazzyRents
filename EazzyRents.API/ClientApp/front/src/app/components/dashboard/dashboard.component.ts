import { Component, OnInit } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealEstateService } from '../../services/realestate.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Address } from '../../models/address';
import { RealEstateStatusModel } from '../../models/realestatestatus.enum';
import { MatDialog } from '@angular/material/dialog';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
  
  baseUrl: any = "https://localhost:44379/";
  realEstates: RealEstateModel[] = [];
  selectedImageUrl: string = '';
  email: string | null = null;
  showAbout: boolean = false;

  constructor(
    private realEstateService: RealEstateService,
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.email = params['email'];
      if (this.email) {
        this.getRealEstate();
      } else {
        console.error('Email not provided in the URL');
      }
    });
  }

  addEstate(){
    this.router.navigate(['/add-realestate']);
  }

  getById(id: number){
    this.realEstateService.getRealEstateById(id);
    this.router.navigate(['/realestate-profile', id]);
  }

  removeById(id: number){
    this.realEstateService.deleteById(id);
    alert('Successfully deleted');
    window.location.reload();

  }

  toggleAbout() {
    this.showAbout = !this.showAbout;
  }
  

  getRealEstate(): void {
    if (this.email) {
      this.realEstateService.getRealEstatesByEmail(this.email).subscribe(
        data => {
          this.realEstates = data;
        },
        error => {
          console.error('Error fetching real estate:', error);
        }
      );
    } else {
      console.error('Email not provided');
    }
  }

  public getAddressString(value: number): string {
    switch (value) {
      case Address.Tashkent:
        return 'Tashkent';
      case Address.Samarkand:
        return 'Samarkand';
      case Address.Bukhara:
        return 'Bukhara';
      default:
        return 'Unknown Address';
    }
  }

  selectImage(imageUrl: string): void {
    this.selectedImageUrl = imageUrl;
  }

  public getRealEstateStatusString(value: number): string {
    switch(value) {
      case RealEstateStatusModel.Active:
        return 'Active';
      case RealEstateStatusModel.Rent:
        return 'Rent';
      case RealEstateStatusModel.Archieve:
        return 'Archieve';
      default:
        return 'Unknown Status';
    }
  }

}
