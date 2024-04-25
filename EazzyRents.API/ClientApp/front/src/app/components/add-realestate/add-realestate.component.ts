import { Component, Input} from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealEstateService } from '../../services/realestate.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-realestate',
  templateUrl: './add-realestate.component.html',
})
export class AddRealestateComponent{
  @Input() realEstate!: RealEstateModel;
  selectedImages: File[] = [];

  constructor(private realEstateService: RealEstateService,
              private http: HttpClient
  ){}


  // Function to handle file selection
  onFileSelected(event: any) {
    this.selectedImages = event.target.files;
  }

  submitNewRealEstate(){
    this.realEstateService.createRealEstate(this.realEstate);
  }

  
}
