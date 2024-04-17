import { Component, OnInit } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealEstateService } from '../../services/realestate.service';

@Component({
  selector: 'app-location-sorting',
  templateUrl: './location-sorting.component.html'
})
export class LocationSortingComponent{
  selectedAddress: number | undefined;
  
  filterVisible: boolean = false;
  

  constructor(private realEstateService: RealEstateService) {}

  toggleFilter() {
    this.filterVisible = !this.filterVisible;
  }

  filterByAddress(addressId: number): void{
    this.realEstateService.getRealEstateByAddress(addressId);
    this.toggleFilter();
  }
  
}
