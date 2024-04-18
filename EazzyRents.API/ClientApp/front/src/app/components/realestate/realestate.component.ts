import { Component, Input } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { Address } from '../../models/address';

@Component({
  selector: 'app-real-estate',
  templateUrl: './realestate.component.html'
})
export class RealEstateComponent {
  @Input() estate: RealEstateModel = {
    id: 0,
    description: '',
    price: '',
    phoneNumber: '',
    address: Address.Tashkent,
    imageUrls: [],
    longitude: 0,
    latitude: 0,
    owner: ''
  }
  
  baseUrl: any = "https://localhost:44379/";


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
