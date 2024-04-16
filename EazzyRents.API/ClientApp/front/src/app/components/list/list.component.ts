import { Component, OnInit } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealEstateService } from '../../services/realestate.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {
  realEstate: string = '';
  realEstates: RealEstateModel[] = [];
  private subscription: Subscription | undefined; 

  constructor(private realEstateService: RealEstateService){}

  ngOnInit() {
    this.realEstateService.getRealEstates();
    this.subscription = this.realEstateService.realEstates$.subscribe(
        (estates) => {
        this.realEstates = estates;
      },
      (error) => {
          console.error('Error fetching real estates', error);
      });
    }

    ngOnDestroy(){
      this.subscription?.unsubscribe();
    }
  }

