import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterLinkActive } from '@angular/router';

interface MenuItem {
  label: string;
  link: string;
  icon: string;
}

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.component.html',
  host: { style: 'display: contents' }
})
export class SidebarComponent {
  searchTerm = '';

  menu: MenuItem[] = [
    { label: 'لوحة التحكم', link: '/dashboard', icon: 'bi-speedometer' },
    { label: 'أصناف الأعلاف', link: '/feed-items', icon: 'bi-box-seam' },
    { label: 'التقارير', link: '/reports', icon: 'bi-bar-chart' },
  ];

  get filteredMenu(): MenuItem[] {
    if (!this.searchTerm.trim()) return this.menu;
    const term = this.searchTerm.toLowerCase();
    return this.menu.filter(m => m.label.toLowerCase().includes(term));
  }
}