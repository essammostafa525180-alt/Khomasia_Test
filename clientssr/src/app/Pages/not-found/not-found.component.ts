import { Component, Inject, Optional, PLATFORM_ID } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Location, CommonModule, isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent {
  constructor(
    private location: Location,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object,
    @Optional() @Inject('RESPONSE') private response: any
  ) {
    // Set 404 status code in SSR
    if (!isPlatformBrowser(this.platformId) && this.response) {
      this.response.status(404);
    }
  }

  goBack(): void {
    if (isPlatformBrowser(this.platformId)) {
      if (window.history.length > 1) {
        this.location.back();
      } else {
        this.router.navigate(['/']);
      }
    } else {
      this.router.navigate(['/']);
    }
  }
}
