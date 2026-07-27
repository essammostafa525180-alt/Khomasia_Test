import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FaviconService } from '../../Services/favicon.service';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-theme-settings',
  imports: [CommonModule, MatTooltipModule],
  templateUrl: './theme-settings.component.html',
  styleUrls: ['./theme-settings.component.css']
})
export class ThemeSettingsComponent implements OnInit {

  constructor(private faviconService: FaviconService) { }

  ngOnInit() {
    // Load saved theme if any
    if (typeof window !== 'undefined') {
      const savedTheme = localStorage.getItem('app-theme');
      if (savedTheme) {
        try {
          const color = JSON.parse(savedTheme);
          this.changeTheme(color, false); // Pass false to avoid redundant save
        } catch (e) {
          console.error('Error parsing saved theme', e);
        }
      } else {
        // Set initial favicon based on default variable if no theme saved
        const color = getComputedStyle(document.documentElement).getPropertyValue('--color-primary-main').trim();
        if (color) {
          this.faviconService.setFavicon(color);
        }
      }
    }
  }

  isOpen = false;
  colors = [
    {
      name: 'Black',
      primary: '#000000',
      light: '#434343',
      dark: '#000000',
      radial: 'radial-gradient(circle at 40% 40%, #0a0a0a, #000000, #2c2c2c)'
    },
    {
      name: 'Deep Blue',
      primary: '#34495e',
      light: '#5d6d7e',
      dark: '#2c3e50',
      radial: 'radial-gradient(circle at 50% 50%, #2e4053, #34495e, #4b5c72)'
    },
    { name: 'Teal', primary: '#2baab1', light: '#4dd0e1', dark: '#00838f', radial: 'radial-gradient(circle at 30% 30%, #00838f, #2baab1, #4dd0e1)' },
    // 2️⃣ Indigo
    {
      name: 'Indigo',
      primary: '#5c6bc0',
      light: '#9fa8da',
      dark: '#3949ab',
      radial: 'radial-gradient(circle at 50% 50%, #4f5db0, #5c6bc0, #7a84d0)'
    },
    // 3️⃣ Blue
    {
      name: 'Blue',
      primary: '#2196f3',
      light: '#64b5f6',
      dark: '#1976d2',
      radial: 'radial-gradient(circle at 50% 50%, #1e87e0, #2196f3, #5aa0f5)'
    },
    // 4️⃣ Red
    {
      name: 'Red',
      primary: '#e74c3c',
      light: '#ff7961',
      dark: '#c0392b',
      radial: 'radial-gradient(circle at 50% 50%, #d84435, #e74c3c, #ed6a58)'
    },
    // 6️⃣ Green
    {
      name: 'Green',
      primary: '#27ae60',
      light: '#7bed9f',
      dark: '#1e8449',
      radial: 'radial-gradient(circle at 50% 50%, #239354, #27ae60, #49c06f)'
    },
    {
      name: 'Orange',
      primary: '#e67e22',
      light: '#f5b041',
      dark: '#af601a',
      radial: 'radial-gradient(circle at 40% 40%, #d6701e, #e67e22, #eb9444)'
    },
    { name: 'Teal', primary: '#1abc9c', light: '#48c9b0', dark: '#16a085', radial: 'radial-gradient(circle at 30% 30%, #16a085, #1abc9c, #48c9b0)' },

    // 7️⃣ Emerald
    // {
    //   name: 'Emerald',
    //   primary: '#2ecc71',
    //   light: '#a3e4d7',
    //   dark: '#1e8449',
    //   radial: 'radial-gradient(circle at 50% 50%, #27b867, #2ecc71, #64d090)'
    // },
    // 8️⃣ Purple
    // {
    //   name: 'Purple',
    //   primary: '#8e44ad',
    //   light: '#af7ac5',
    //   dark: '#6c3483',
    //   radial: 'radial-gradient(circle at 50% 50%, #7b3fa0, #8e44ad, #a569c1)'
    // },
    // 9️⃣ Pink
    // {
    //   name: 'Pink',
    //   primary: '#e91e63',
    //   light: '#f48fb1',
    //   dark: '#b0154a',
    //   radial: 'radial-gradient(circle at 50% 50%, #d91a5a, #e91e63, #f06587)'
    // },
    // 🔟 Cyan
    // {
    //   name: 'Cyan',
    //   primary: '#00bcd4',
    //   light: '#62efff',
    //   dark: '#008ba3',
    //   radial: 'radial-gradient(circle at 50% 50%, #00a4c0, #00bcd4, #33d1e0)'
    // },
    // 11️⃣ Orange
    // // 12️⃣ Lime
    // {
    //   name: 'Lime',
    //   primary: '#cddc39',
    //   light: '#f0ff72',
    //   dark: '#99aa00',
    //   radial: 'radial-gradient(circle at 50% 50%, #c0d430, #cddc39, #d9e956)'
    // },
    // 13️⃣ Deep Blue
  ];



  toggleSettings() {
    this.isOpen = !this.isOpen;
  }

  changeTheme(color: any, save: boolean = true) {

    const root = document.documentElement;

    root.style.setProperty('--color-primary-main', color.primary);
    root.style.setProperty('--color-primary-light', color.light);
    root.style.setProperty('--color-primary-dark', color.dark);

    if (color.radial) {
      root.style.setProperty('--color-primary-gradient', color.radial);
    }
    const contrast = this.getContrastColor(color.primary);
    root.style.setProperty('--text-on-primary', contrast);

    this.faviconService.setFavicon(color.primary);

    if (save && typeof window !== 'undefined') {
      localStorage.setItem('app-theme', JSON.stringify(color));
    }

  }

  closeSettings() {
    this.isOpen = false;
  }

  private getContrastColor(hex: string): string {
    const h = hex.replace('#', '');
    const r = parseInt(h.substring(0, 2), 16);
    const g = parseInt(h.substring(2, 4), 16);
    const b = parseInt(h.substring(4, 6), 16);
    const luminance = (0.299 * r + 0.587 * g + 0.114 * b) / 255;
    return luminance > 0.6 ? '#000000' : '#ffffff';
  }

}
