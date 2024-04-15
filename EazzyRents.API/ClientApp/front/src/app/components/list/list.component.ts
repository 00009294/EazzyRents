import { Component, OnInit } from '@angular/core';
import { RealEstateModel } from '../../models/realestate.model';
import { RealestateService } from '../../services/realestate.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  realEstates: RealEstateModel[] = [];

  constructor(private realEstateService: RealestateService){}

  ngOnInit() {
    this.realEstateService.getRealEstates().subscribe({
      next: (estates) => {
        this.realEstates = estates.map(estate => ({
          ...estate,
          // Adjust the path to where your backend serves the images
        }));
      },
      error: (error) => {
        console.error('Error fetching real estates', error);
      }
    });
    
  }
}
