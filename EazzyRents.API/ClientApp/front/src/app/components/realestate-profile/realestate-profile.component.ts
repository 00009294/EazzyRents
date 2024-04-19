import { Component, OnInit, Input,  AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { RealEstateService } from '../../services/realestate.service';
import { RealEstateModel } from '../../models/realestate.model';
import { ActivatedRoute } from '@angular/router';
import { Address } from '../../models/address';
import { CommentModel } from '../../models/comment';
import { CommentService } from './../../services/comment.service';
import * as L from 'leaflet';
@Component({
  selector: 'app-realestate-profile',
  templateUrl: './realestate-profile.component.html'
})

export class RealestateProfileComponent implements OnInit{
  baseUrl: any = "https://localhost:44379/";
  @Input() realEstate: RealEstateModel = {
    id: 0,
    description: '',
    price: '',
    phoneNumber: '',
    about: '',
    address: Address.Tashkent,
    imageUrls: [],
    longitude: 0,
    latitude: 0,
    owner: ''
  }

  comments: CommentModel[] = [];
  @Input() comment: CommentModel | undefined;
  selectedImageUrl: string = '';
  id: number | any;
  longitude: number | any;
  latitude: number | any;

constructor(private realEstateService: RealEstateService, 
  private commentService: CommentService,
  private route: ActivatedRoute){}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    })
    this.getRealEstate();
    this.commentService.getComments(this.id).subscribe(
      (data: CommentModel[]) => {
        this.comments = data;
      }
    )
    
  }
  
  getRealEstate(): void{
    if(this.id){
      this.realEstateService.getRealEstateById(this.id).subscribe(
        data => {
          this.realEstate = data;
          if (this.realEstate.imageUrls.length > 0) {
            this.selectedImageUrl = this.realEstate.imageUrls[0];
          }
        },
        error => {
          console.error('Real estate not found', error);
        }
      );
    }
    else {
      console.error('ID not provided');
    }
  }

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

  selectImage(imageUrl: string): void {
    this.selectedImageUrl = imageUrl;
  }

}
