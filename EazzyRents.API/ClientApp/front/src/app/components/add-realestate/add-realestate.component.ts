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
    ImageDataList: new FormData(),
    PhoneNumber: 0,
    Address: Address.Bukhara,
    Longitude: '69.245443',
    Latitude: '41.339668',
    Email: '',
    RealEstateStatus: RealEstateStatusModel.Archieve,
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

  selectedAddress!: Address;
  selectedStatus!: RealEstateStatusModel;
  selectedCoordinates!: { latitude: number, longitude: number };
  selectedImages: File[] = [];
  
  

  constructor(private realEstateService: RealEstateService,
    private http: HttpClient,
    private auth: RegistrationService,
    private userService: UserService,
    private router: Router
  ){}
  
  submitNewRealEstate(){
    const token = this.auth.getToken();
    
    //console.log(this.selectedImages);
    //this.realEstate.ImageDataList = this.selectedImages;
    //console.log(this.realEstate.ImageDataList)
    
    this.userService.getByToken(token!).subscribe({
      next: (user: ProfileModel) => {
        this.realEstate.Email = user.email;
        this.realEstate.Owner = user.userName;
        this.realEstate.Address = this.selectedAddress;
        this.realEstate.RealEstateStatus = this.selectedStatus;

        console.log("Inside getBy Token selected Images: "+this.selectedImages);

        // Assign extracted files to ImageDataList

        const formData = new FormData();

    // Append each selected image file to the FormData object
    for (const selectedImage of this.selectedImages) {
      formData.append('files', selectedImage);
    }
      console.log('Form Data' + formData);
        //this.realEstate.ImageDataList = this.selectedImages;
          
        console.log("Inside getBy Token: "+this.realEstate.ImageDataList);

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
      }
    )}
  
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

// Create a new FormData object
// Define a property to hold the FormData object

// Define a property to hold the URLs of selected images
selectedImageUrls: string[] = [];

onFileSelected(event: any) {
  const files: FileList = event.target.files;
  if (files && files.length > 0) {
    // Clear existing files before adding new ones
    this.selectedImages = [];
    // Clear existing selected image URLs before adding new ones
    this.selectedImageUrls = [];
    
    for (let i = 0; i < files.length; i++) {
      // Append each File object to the FormData object
      this.selectedImages.push(files[i]);
      //console.log(files[i]);
      // this.selectedImages.forEach((value: File | string, key: string) => {
      //   console.log(`${key}: ${value}`);
      // });
      

      // Read the file as a URL and push the URL to selectedImageUrls
      const reader = new FileReader();
      reader.onload = (e) => {
        if (typeof e.target?.result === 'string') {
          this.selectedImageUrls.push(e.target.result);
        }
      };
      reader.readAsDataURL(files[i]);
    }
  }
}



}

