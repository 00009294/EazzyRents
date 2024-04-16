import { Component, Input } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';

@Component({
  selector: 'app-real-estate',
  templateUrl: './realestate.component.html'
})
export class RealEstateComponent {
  @Input() estate!: RealEstateModel;

  baseUrl: any = "https://localhost:44379/";
}
