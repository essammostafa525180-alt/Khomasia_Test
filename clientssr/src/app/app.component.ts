import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingService } from './Services/loading.service';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from "./Components/footer/footer.component";
import { HeaderComponent } from "./Components/header/header.component";
import { ThemeSettingsComponent } from "./Components/theme-settings/theme-settings.component";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { ScrollToTopComponent } from './Components/scroll-to-top/scroll-to-top.component';
import { NarratorsDetailsPageComponent } from './Pages/narrators-details-page/narrators-details-page.component';
import { MatDialog } from '@angular/material/dialog';
import { SearchResultComponent } from "./Components/search-result/search-result.component";
import { SharedService } from './Services/shared.service';
import { FontSettingsComponent } from './Components/font-settings/font-settings.component';
import { TooltipService } from './Services/tooltip.service';
import { CanonicalService } from './Services/canonical.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet, FooterComponent, HeaderComponent, ThemeSettingsComponent, MatProgressSpinnerModule, ScrollToTopComponent, SearchResultComponent, FontSettingsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  isSearching = false;

  constructor(
    public loading: LoadingService,
    private router: Router,
    public dialog: MatDialog,
    private sharedService: SharedService,
    private tooltipService: TooltipService,
    private canonicalService: CanonicalService
  ) { }
  @HostListener('click', ['$event'])
  onComponentClick(event: Event) {
    const target = event.target as HTMLElement;

    if (target?.classList.contains('rawi-profile')) {
      const rawiId = target.getAttribute('data-id');
      if (rawiId) {
        this.RawiProfile(+rawiId);
      }
    }
  }

  RawiProfile(id: number) {
    this.dialog.open(NarratorsDetailsPageComponent, {
      width: '90vw',
      maxWidth: '800px',
      height: 'auto',
      panelClass: 'rawi-dialog',
      data: { narratorId: id },
    });
  }
  ngOnInit(): void {
    this.tooltipService.initGlobalTooltipListeners();
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.loading.start();
        this.sharedService.clearSearch(); 
      }

      if (
        event instanceof NavigationEnd ||
        event instanceof NavigationCancel ||
        event instanceof NavigationError
      ) {
        this.loading.stop();

        if (event instanceof NavigationEnd) {
          this.sharedService.clearSearch();
          
          const currentUrl = `${environment.Domain}${event.urlAfterRedirects || event.url}`;
          this.canonicalService.setCanonical(currentUrl);
        }
      }
    });

    this.sharedService.isSearching$.subscribe(state => {
      this.isSearching = state;
    });
  }



  label = 'جامع السنة وشروحها';

}
