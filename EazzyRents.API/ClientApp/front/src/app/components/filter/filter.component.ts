import { Component } from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html'
})
export class FilterComponent {
  filterVisible: boolean = false;
  fromPrice: number | undefined;
  toPrice: number | undefined;

  constructor(private realEstateService: RealEstateService) {}

  toggleFilter() {
    this.filterVisible = !this.filterVisible;
  }

  searchByPriceRange() {
    if(this.fromPrice !== undefined && this.toPrice !== undefined){
      this.realEstateService.getRealEstateByPrice(this.fromPrice, this.toPrice);
      this.toggleFilter();
    }
    
  }


}
