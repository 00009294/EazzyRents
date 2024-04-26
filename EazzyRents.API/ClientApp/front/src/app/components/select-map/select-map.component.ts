import { Component, ElementRef, EventEmitter, OnInit, Output } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-select-map',
  templateUrl: './select-map.component.html',
})
export class SelectMapComponent implements OnInit {
  @Output() coordinatesSelected = new EventEmitter<{ latitude: number, longitude: number }>();

  map: any;

  constructor(private elementRef: ElementRef) {}

  ngOnInit(): void {
    this.initMap();
  }

  initMap(): void {
    this.map = L.map(this.elementRef.nativeElement).setView([51.505, -0.09], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(this.map);

    let marker: any;

    this.map.on('click', (e: any) => {
      if (marker) {
        marker.setLatLng(e.latlng);
      } else {
        marker = L.marker(e.latlng).addTo(this.map);
      }

      const latitude = e.latlng.lat;
      const longitude = e.latlng.lng;

      this.coordinatesSelected.emit({ latitude, longitude });
    });
  }
}
