import { Component, OnInit } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealEstateService } from '../../services/realestate.service';

@Component({
  selector: 'app-location-sorting',
  templateUrl: './location-sorting.component.html'
})
export class LocationSortingComponent implements OnInit{
  selectedAddress: number | undefined;
  addresses = [
    { id: 0, name: 'Tashkent' },
    { id: 1, name: 'Samarkand' },
    { id: 2, name: '' },
  ];
  filterVisible: boolean = false;
  realEstates: RealEstateModel[] = [];

  constructor(private realEstateService: RealEstateService) {}

  ngOnInit() {
    this.filterByAddress(0);
  }

  filterByAddress(addressId: number): void{
    this.realEstateService.getRealEstateByAddress(addressId).subscribe(
      (estates) => {
        this.realEstates = estates;
      },
      (error) =>{
        console.log('Error while fetching real estates');
      }
    );
  }

  onSubmit() {
    if (this.selectedAddress !== undefined) {
      this.realEstateService.getRealEstateByAddress(this.selectedAddress).subscribe(
        realEstates => {
          // Now you have your filtered real estates
          // Close the filter subwindow
          this.toggleFilter();
          // Do something with the filtered real estates...
        },
        error => {
          console.error('Error fetching real estates by address', error);
        }
      );
    }
  }

  toggleFilter(){
    this.filterVisible = !this.filterVisible;
  }

}
