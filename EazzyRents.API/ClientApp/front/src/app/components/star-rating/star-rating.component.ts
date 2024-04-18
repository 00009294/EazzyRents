import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-star-rating',
  templateUrl: './star-rating.component.html'
})
export class StarRatingComponent implements OnChanges{
  @Input() rating: number | undefined;
  stars: boolean[] = [];

  ngOnChanges(): void {
    this.stars = Array(5).fill(false);
    if (this.rating !== undefined) {
      for (let i = 0; i < this.rating; i++) {
        this.stars[i] = true;
      }
    }
  }

}
