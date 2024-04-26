import { Component, Input} from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { HttpClient } from '@angular/common/http';
import { Address } from '../../models/address';
import { RealEstateStatusModel } from '../../models/realestatestatus.enum';
import { AddRealEstateModel } from '../../models/addrealestate.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-realestate',
  templateUrl: './add-realestate.component.html',
})
export class AddRealestateComponent{
  realEstate: AddRealEstateModel = {
    Id: 0,
    Description: '',
    About: '',
    Price: '',
    ImageDataList: ['360_F_581507560_Xv9uwZdXwZU9pKSJuLf25OIBSmObT4FW', 'white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9'],
    PhoneNumber: 0,
    Address: Address.Tashkent,
    Longitude: '69.245443',
    Latitude: '41.339668',
    Email: '',
    RealEstateStatus: RealEstateStatusModel.Active,
    Owner: ''
  };
  selectedImages: File[] = [];
  selectedAddress: Address | null = null;
  selectedStatus: number | null = null;
  selectedCoordinates!: { latitude: number, longitude: number };



  constructor(private realEstateService: RealEstateService,
              private http: HttpClient,
              private router: Router
  ){}

  submitNewRealEstate(){
    console.log(this.realEstate.ImageDataList);
    this.realEstateService.createRealEstate(this.realEstate).subscribe({
      next: (response) =>{
        alert('Successfully added');
        this.router.navigate([`/dashboard/${this.realEstate.Email}`]);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  onCoordinatesSelected(coordinates: { latitude: string, longitude: string }): void {
    this.realEstate.Latitude = coordinates.latitude;
    this.realEstate.Longitude = coordinates.longitude;
  }
  // Define array of enum values
  selectStatus(status: number) {
    this.selectedStatus = status;
    // Additional logic if needed
  }
  
  selectAddress(address: string) {
    this.selectedAddress = Address[address as keyof typeof Address];
    // Additional logic if needed
  }

  // Function to handle file selection
  onFilesSelected(event: any) {
    const files: FileList = event.target.files;
    if (files && files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        const file: File = files[i];
        // Check if the file type is either PNG or JPEG
        if (file.type === 'image/png' || file.type === 'image/jpeg') {
          // Perform additional logic if needed, such as uploading the file
          // For now, let's just store the file URL
          const reader = new FileReader();
          reader.onload = (e: any) => {
            //this.realEstate.ImageDataList.push(e.target.result);
          };
          reader.readAsDataURL(file);
        } else {
          console.log('Invalid file type. Please select PNG or JPEG files.');
        }
      }
    }
  }
}
