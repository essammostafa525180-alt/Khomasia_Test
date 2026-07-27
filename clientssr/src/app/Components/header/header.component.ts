import { Component, HostListener, OnInit, Inject, PLATFORM_ID, OnDestroy, NgZone, ChangeDetectorRef } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { isPlatformBrowser } from '@angular/common';
import { MenusComponent } from "../menus-mobile/menus-mobile.component";
import { DropDownComponent } from "../menus-desktop/menus-desktop.component";
import { CommonModule } from '@angular/common';
import { HadithService } from '../../Services/hadith.service';
import { Partition } from '../../Model/Partition/partition';
import { RouterLink } from "@angular/router";
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { Classification } from '../../Model/Classification/classification';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { MatDialog } from '@angular/material/dialog';
import { SharedService } from '../../Services/shared.service';
import { FormsModule } from '@angular/forms';

import { NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [CommonModule, DropDownComponent, MenusComponent, RouterLink, FormsModule, NgOptimizedImage],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit, OnDestroy {

  partitions: Partition[] = [];
  currentTime: string = '';
  private timer: any;

  constructor(
    private _service: HadithService,
    public dialog: MatDialog,
    private sharedService: SharedService,
    private ngZone: NgZone,
    private cdr: ChangeDetectorRef,
    private breakpointObserver: BreakpointObserver,
    @Inject(PLATFORM_ID) private platformId: Object
  ) { }

  ngOnInit(): void {

    this.GetMenus();
    this.getAllClassification();

    if (isPlatformBrowser(this.platformId)) {
      this.breakpointObserver.observe('(min-width: 769px)').subscribe(result => {
        this.isDesktop = result.matches;
        this.cdr.detectChanges();
      });
      this.startClock();
      this.subscribeToSearch();
    }
  }

  private subscribeToSearch() {
    this.sharedService.searchParams$.subscribe(params => {
      if (!params) {
        this.searchText = '';
      }
    });
  }

  ngOnDestroy(): void {
    if (this.timer) {
      clearInterval(this.timer);
    }
  }

  startClock() {
    this.updateTime();
    this.ngZone.runOutsideAngular(() => {
      this.timer = setInterval(() => {
        this.updateTime();
        this.cdr.detectChanges(); // Update only this component
      }, 1000);
    });
  }

  updateTime() {
    const now = new Date();
    this.currentTime = now.toLocaleTimeString('ar-EG', {
      timeZone: 'Africa/Cairo',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit',
      hour12: true
    });
  }

  showHumburger: boolean = false
  isDropdownOpen: boolean = false;
  selectedClassificationName: string = 'كل التصنيفات';
  selectedClassificationId: number | null = null;
  filterText: string = '';
  searchText: string = '';

  onSearch() {
    this.sharedService.updateSearch({
      query: this.searchText,
      classificationId: this.selectedClassificationId
    });
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
    if (!this.isDropdownOpen) this.filterText = '';
  }

  get filteredClassifications() {
    if (!this.filterText) return this.classifications;
    return this.classifications.filter(c =>
      c.name?.toLowerCase().includes(this.filterText.toLowerCase())
    );
  }

  onFilterChange(event: any) {
    this.filterText = event.target.value;
  }

  selectClassification(name: string, id: number | null) {
    this.selectedClassificationName = name;
    this.selectedClassificationId = id;
    this.isDropdownOpen = false;
  }

  @HostListener('document:click', ['$event'])
  clickout(event: any) {
    // إغلاق قائمة التصنيفات
    if (!event.target.closest('.select-wrapper')) {
      this.isDropdownOpen = false;
    }

    // إغلاق منيو الهامبرجر عند الضغط بالخارج
    if (!event.target.closest('.humborger') &&
      !event.target.closest('.desktop-navigation-wrapper') &&
      !event.target.closest('.accordion')) {
      this.showHumburger = false;
    }
  }

  classifications: Classification[] = [];
  getAllClassification() {
    this._service.getAllClassification().subscribe({
      next: (res: ApiResponse<PagedResult<Classification>>) => {
        this.classifications.push(...res.data.items);
      }
    });
  }

  GetMenus() {
    this._service.getAllPartitions().subscribe({
      next: (res) => {
        if (res.isSuccess && res.data) {
          this.partitions = res.data.items;
        }
      },
    });
  }

  isDesktop: boolean = true;

  toggelHumburger() {
    this.showHumburger = !this.showHumburger
  }


  getHijriDate(): string {
    const today = new Date();
    const hijriFormatter = new Intl.DateTimeFormat('ar-SA-u-ca-islamic', {
      timeZone: 'Africa/Cairo',
      weekday: 'long',
      day: 'numeric',
      month: 'long',
      year: 'numeric'
    });
    return hijriFormatter.format(today);
  }

  async contactUs() {
    const { ContactUsPageComponent } = await import('../../Pages/contact-us-page/contact-us-page.component');
    this.dialog.open(ContactUsPageComponent, {
      width: '80vw',
      maxWidth: '500px',
      height: 'auto',
      panelClass: 'contact-dialog',
    });
  }


}
