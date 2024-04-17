import { Pipe, PipeTransform } from '@angular/core';
import { Address } from '../models/address';

@Pipe({
  name: 'address'
})
export class AddressPipe implements PipeTransform {

  transform(value: Address): string {
    switch(value){
      case Address.Tashkent: 
        return 'Tashkent';
      case Address.Samarkand: 
        return 'Samarkand';
      case Address.Bukhara: 
        return 'Bukhara';
      default: 
        return 'Unknown';  
    }
  }

}
