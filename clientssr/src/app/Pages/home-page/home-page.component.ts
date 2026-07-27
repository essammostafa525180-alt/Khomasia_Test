import { Component, OnInit, AfterViewInit, OnDestroy, ElementRef, ViewChildren, QueryList, Inject, PLATFORM_ID, NgZone, ChangeDetectorRef } from '@angular/core';
import { CommonModule, DecimalPipe, isPlatformBrowser } from '@angular/common';
import { RouterLink } from "@angular/router";

interface StatItem {
  label: string;
  value: number;
  currentValue?: number;
}

@Component({
  selector: 'app-home-page',
  imports: [RouterLink, CommonModule],
  providers: [DecimalPipe],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren('reveal') revealElements!: QueryList<ElementRef>;
  // --- Data & State Variables ---

  tickerTexts: string[] = [
    '﴿ وَمَا يَنطِقُ عَنِ الْهَوَىٰ ۝ إِنْ هُوَ إِلَّا وَحْيٌ يُوحَىٰ ﴾',
    'نَضَّرَ اللَّهُ امرأً سَمِعَ مِنَّا حديثًا فبلَّغَه كما سمعه',
    'بُلِّغُوا عَنِّي وَلَوْ آيَةً',
    'مَنْ يُرِدِ اللَّهُ بِهِ خَيْرًا يُفَقِّهْهُ فِي الدِّينِ'
  ];

  stats: StatItem[] = [
    { label: 'عدد الأحاديث', value: 477370, currentValue: 0 },
    { label: 'كتب الشروح', value: 16, currentValue: 0 },
    { label: 'عدد الرواة', value: 25997, currentValue: 0 },
    { label: 'عدد التصنيفات', value: 245, currentValue: 0 }
  ];

  private observer!: IntersectionObserver;
  private countersTriggered = false;
  private rafIds: number[] = [];

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private ngZone: NgZone,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void { }

  ngAfterViewInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      this.setupRevealObserver();
    }
  }

  ngOnDestroy(): void {
    if (this.observer) {
      this.observer.disconnect();
    }
    this.rafIds.forEach(id => cancelAnimationFrame(id));
  }

  private setupRevealObserver(): void {
    this.observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('in-view');

          if (entry.target.classList.contains('stats-section') && !this.countersTriggered) {
            this.countersTriggered = true;
            this.runCounters();
          }

          this.observer.unobserve(entry.target);
        }
      });
    }, { threshold: 0.15 });

    setTimeout(() => {
      this.revealElements.forEach(el => this.observer.observe(el.nativeElement));
    }, 100);
  }

  private runCounters(): void {
    this.ngZone.runOutsideAngular(() => {
      this.stats.forEach((stat, index) => {
        const duration = 2000 + (index * 200);
        const start = performance.now();
        const targetValue = stat.value;

        const animate = (time: number) => {
          const elapsed = time - start;
          const progress = Math.min(elapsed / duration, 1);

          // Ease out quint
          const ease = 1 - Math.pow(1 - progress, 5);

          stat.currentValue = Math.floor(ease * targetValue);

          // Force local CD update
          this.cdr.detectChanges();

          if (progress < 1) {
            this.rafIds.push(requestAnimationFrame(animate));
          } else {
            stat.currentValue = targetValue;
            this.cdr.detectChanges();
          }
        };

        this.rafIds.push(requestAnimationFrame(animate));
      });
    });
  }

  getStatIcon(index: number): string {
    const icons = [
      'fas fa-scroll',      // Hadith
      'fas fa-pen-fancy',   // Sharh
      'fas fa-users',       // Narrators
      'fas fa-book'         // Books
    ];
    return icons[index] || 'fas fa-check-circle';
  }
}
