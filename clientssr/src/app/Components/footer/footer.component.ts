import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Router, NavigationStart, NavigationEnd, RouterLink } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';


@Component({
    selector: 'app-footer',
    imports: [CommonModule, RouterLink],
    templateUrl: './footer.component.html',
    styleUrl: './footer.component.css'
})
export class FooterComponent implements OnInit {
  executionTime: string = '0.00';
  private startTime: number = 0;

  constructor(
    private router: Router, 
    public dialog: MatDialog,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  async contactUs() {
    const { ContactUsPageComponent } = await import('../../Pages/contact-us-page/contact-us-page.component');
    this.dialog.open(ContactUsPageComponent, {
      width: '60vw',
      maxWidth: '500px',
      height: 'auto',
      panelClass: 'contact-dialog',
    });
  }

  ngOnInit() {
    if (isPlatformBrowser(this.platformId)) {
      this.router.events.subscribe(event => {
        if (event instanceof NavigationStart) {
          this.startTime = performance.now();
        } else if (event instanceof NavigationEnd) {
          const endTime = performance.now();
          const duration = (endTime - this.startTime) / 1000;
          this.executionTime = duration.toFixed(2);
        }
      });

      if (this.startTime === 0) {
        this.executionTime = (performance.now() / 1000).toFixed(2);
      }
    }
  }
}
