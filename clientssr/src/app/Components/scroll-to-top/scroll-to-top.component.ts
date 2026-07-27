import { Component, HostListener, Inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule, DOCUMENT } from '@angular/common';

@Component({
    selector: 'app-scroll-to-top',
    imports: [CommonModule],
    templateUrl: './scroll-to-top.component.html',
    styleUrls: ['./scroll-to-top.component.css']
})
export class ScrollToTopComponent {
  isVisible = false;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private cdr: ChangeDetectorRef
  ) { }

  @HostListener('window:scroll')
  checkScroll() {
    const scrollPosition = window.pageYOffset || this.document.documentElement.scrollTop || this.document.body.scrollTop || 0;
    this.isVisible = scrollPosition >= 200; // Reduced threshold to 200px
    this.cdr.detectChanges(); // Ensure UI updates
  }

  scrollToTop() {
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  }
}
