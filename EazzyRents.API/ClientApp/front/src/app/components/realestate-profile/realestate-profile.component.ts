import { Component, OnInit, Input } from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { RealEstateModel } from '../../models/realestate.model';
import { ActivatedRoute } from '@angular/router';
import { Address } from '../../models/address';
@Component({
  selector: 'app-realestate-profile',
  templateUrl: './realestate-profile.component.html'
})

export class RealestateProfileComponent implements OnInit{
  @Input() realEstate!: RealEstateModel;
  id: number | any;
  longitude: number | any;
  latitude: number | any;
  baseUrl: any = "https://localhost:44379/";

constructor(private realEstateService: RealEstateService, private route: ActivatedRoute){}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    })
    this.getRealEstate();
  }
  
  getRealEstate(): void{
    if(this.id){
      this.realEstateService.getRealEstateById(this.id).subscribe(
        data => {
          this.realEstate = data;
        },
        error => {
          console.error('Real estate not found', error);
        }
      );
    }
    else {
      console.error('ID not provided');
    }
  }
  public getAddressString(value: Address): string {
    switch(value) {
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
}
