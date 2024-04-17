// map.component.ts
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-map',
  template: `
  <google-map
    [center]="center"
    [zoom]="zoom"
    [options]="mapOptions"
    class="w-full h-full">
  </google-map>
`,styles: []
})
export class MapComponent implements OnInit {
  @Input() latitude!: number;
  @Input() longitude!: number;

  zoom: number = 15; // Zoom level for the map
  center!: google.maps.LatLngLiteral; // Center of the map
  mapOptions: google.maps.MapOptions = {
    mapTypeId: 'roadmap', // Type of map to display
  };

  ngOnInit(): void {
    this.center = {
      lat: this.latitude,
      lng: this.longitude,
    };
  }
}
