import { Component, Input } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';

@Component({
  selector: 'app-real-estate',
  templateUrl: './realestate.component.html',
  styleUrl: './realestate.component.css'
})
export class RealestateComponent {
  @Input() estate!: RealEstateModel;
}
