import { Component, Input} from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { HttpClient } from '@angular/common/http';
import { Address } from '../../models/address';
import { RealEstateStatusModel } from '../../models/realestatestatus.enum';
import { AddRealEstateModel } from '../../models/addrealestate.model';
import { Router } from '@angular/router';
import { RegistrationService } from '../../services/registration.service';
import { UserService } from '../../services/user.service';
import { ProfileModel } from '../../models/profile.model';

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
    ImageDataList: [],
    PhoneNumber: 0,
    Address: Address.Bukhara,
    Longitude: '69.245443',
    Latitude: '41.339668',
    Email: '',
    RealEstateStatusModel: RealEstateStatusModel.Archieve,
    Owner: ''
  };
  
  address!: Address;
  realEstateStatusModel!: RealEstateStatusModel;

  sender: ProfileModel ={
    id: '',
    userName: '',
    email: '',
    userRole: ''
  };

  selectedImages: string[] = [];
  selectedAddress!: Address;
  selectedStatus!: RealEstateStatusModel;
  selectedCoordinates!: { latitude: number, longitude: number };




  constructor(private realEstateService: RealEstateService,
              private http: HttpClient,
              private auth: RegistrationService,
              private userService: UserService,
              private router: Router
  ){}

  submitNewRealEstate(){
    const token = this.auth.getToken();
    
    this.userService.getByToken(token!).subscribe({
      next: (user: ProfileModel) => {
        this.realEstate.Email = user.email;
        this.realEstate.Owner = user.userName;
        this.realEstate.Address = this.selectedAddress;
        this.realEstate.RealEstateStatusModel = this.selectedStatus;
        this.realEstate.ImageDataList = this.selectedImages;
        console.log(this.selectedImages);
        
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
    })
  }

  onCoordinatesSelected(coordinates: { latitude: string, longitude: string }): void {
    this.realEstate.Latitude = coordinates.latitude;
    this.realEstate.Longitude = coordinates.longitude;
  }
  // Define array of enum values

  selectStatus(status: string) {
    this.selectedStatus = RealEstateStatusModel[status as keyof typeof RealEstateStatusModel];
    // Additional logic if needed
  }
  
  selectAddress(address: string) {
    this.selectedAddress = Address[address as keyof typeof Address];
    // Additional logic if needed
  }
// Method to handle file selection
onFileSelected(event: any) {
  const files: FileList = event.target.files;
  if (files && files.length > 0) {
    // Clear existing file names before adding new ones
    this.selectedImages = [];

    for (let i = 0; i < files.length; i++) {
      // Extract file name without extension
      const fileName = files[i].name.split('.').slice(0, -1).join('.');
      // Store only the file name without extension
      this.selectedImages.push(fileName);
    }
  }
}

}

