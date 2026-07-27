import { Input, OnInit, PLATFORM_ID, Output, EventEmitter, Component, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Partition } from '../../Model/Partition/partition';
import { HadithCollection } from '../../Model/Hadith/hadith-collection';
import { Classification } from '../../Model/Classification/classification';
import { Menu } from '../../Constants/MenuLabels';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-menus',
  imports: [RouterLink],
  templateUrl: './menus-mobile.component.html',
  styleUrl: './menus-mobile.component.css'
})
export class MenusComponent implements OnInit {

  Menu = Menu;
  @Input({ required: true }) partitions!: Partition[];
  @Output() closeMenu = new EventEmitter<void>();
  isBrowser: boolean;

  constructor(@Inject(PLATFORM_ID) platformId: Object) {
    this.isBrowser = isPlatformBrowser(platformId);
  }
  ngOnInit(): void {
    //  this.isAccordionVisible = true;
  }

  onLinkClick(item: any) {
    if (item.id === Menu.Narrators || item.id === Menu.Home) {
      this.closeMenu.next();
    }
    this.toggle(item);
  }

  closeAccordion() {
    this.closeMenu.next();
  }

  isMobile(): boolean {
    return this.isBrowser && window.innerWidth <= 992;
  }

  toggle(item: Partition) {
    if (!this.isMobile() || !item.hadithCollections) return;
    item.hasCollection = !item.hasCollection;
  }
  toggleSub(item: HadithCollection) {
    if (!this.isMobile() || !item.classifications) return;
    item.mainMenuEnabled = !item.mainMenuEnabled;
  }

  getTopClassifications(classifications: Classification[]): Classification[] {
    return [...classifications]
      .sort((a, b) => {
        const yearA = parseInt(a.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        const yearB = parseInt(b.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        return yearA - yearB;
      })
      .slice(0, 10);
  }
}