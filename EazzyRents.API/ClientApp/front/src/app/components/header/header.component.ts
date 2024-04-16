import { Component } from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { RealEstateModel } from '../../models/realestate.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  searchName: string = '';
  realEstates: RealEstateModel[] = [];

  constructor(private realestateService: RealEstateService){}

  onSearch(name: string) : void {
    this.realestateService.getRealEstatesByName(name);
  }
}
