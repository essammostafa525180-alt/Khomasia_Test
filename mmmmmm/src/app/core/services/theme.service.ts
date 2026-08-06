import { Injectable, signal, computed } from '@angular/core';

export interface AppTheme {
  id: string;
  name: string;
  accent: string;
  accentDark: string;
  accentLight: string;
  accentSoft: string;
  accentHover: string;
  accentShadow: string;
  rowHover: string;
  banner: string;
}

export const APP_THEMES: AppTheme[] = [
  {
    id: 'blue',
    name: 'Ocean Blue',
    accent: '#2563eb',
    accentDark: '#1d4ed8',
    accentLight: '#3b82f6',
    accentSoft: '#eff6ff',
    accentHover: '#dbeafe',
    accentShadow: 'rgba(37, 99, 235, 0.25)',
    rowHover: '#f0f7ff',
    banner: 'linear-gradient(135deg, #e0f2fe 0%, #bae6fd 50%, #93c5fd 100%)',
  },
  {
    id: 'green',
    name: 'Forest Green',
    accent: '#16a34a',
    accentDark: '#15803d',
    accentLight: '#22c55e',
    accentSoft: '#f0fdf4',
    accentHover: '#dcfce7',
    accentShadow: 'rgba(22, 163, 74, 0.25)',
    rowHover: '#f0fdf4',
    banner: 'linear-gradient(135deg, #dcfce7 0%, #bbf7d0 50%, #86efac 100%)',
  },
  {
    id: 'purple',
    name: 'Royal Purple',
    accent: '#7c3aed',
    accentDark: '#6d28d9',
    accentLight: '#8b5cf6',
    accentSoft: '#f5f3ff',
    accentHover: '#ede9fe',
    accentShadow: 'rgba(124, 58, 237, 0.25)',
    rowHover: '#f5f3ff',
    banner: 'linear-gradient(135deg, #ede9fe 0%, #ddd6fe 50%, #c4b5fd 100%)',
  },
  {
    id: 'rose',
    name: 'Rose Red',
    accent: '#e11d48',
    accentDark: '#be123c',
    accentLight: '#f43f5e',
    accentSoft: '#fff1f2',
    accentHover: '#ffe4e6',
    accentShadow: 'rgba(225, 29, 72, 0.25)',
    rowHover: '#fff1f2',
    banner: 'linear-gradient(135deg, #ffe4e6 0%, #fecdd3 50%, #fda4af 100%)',
  },
  {
    id: 'amber',
    name: 'Amber Gold',
    accent: '#d97706',
    accentDark: '#b45309',
    accentLight: '#f59e0b',
    accentSoft: '#fffbeb',
    accentHover: '#fef3c7',
    accentShadow: 'rgba(217, 119, 6, 0.25)',
    rowHover: '#fffbeb',
    banner: 'linear-gradient(135deg, #fef3c7 0%, #fde68a 50%, #fcd34d 100%)',
  },
  {
    id: 'cyan',
    name: 'Teal Cyan',
    accent: '#0891b2',
    accentDark: '#0e7490',
    accentLight: '#06b6d4',
    accentSoft: '#ecfeff',
    accentHover: '#cffafe',
    accentShadow: 'rgba(8, 145, 178, 0.25)',
    rowHover: '#ecfeff',
    banner: 'linear-gradient(135deg, #cffafe 0%, #a5f3fc 50%, #67e8f9 100%)',
  },
];

const STORAGE_KEY = 'app-theme-id';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  private _currentThemeId = signal<string>(
    localStorage.getItem(STORAGE_KEY) ?? 'blue'
  );

  readonly currentThemeId = this._currentThemeId.asReadonly();

  readonly currentTheme = computed(() =>
    APP_THEMES.find((t) => t.id === this._currentThemeId()) ?? APP_THEMES[0]
  );

  readonly themes = APP_THEMES;

  constructor() {
    // Apply saved theme on startup
    this.applyTheme(this.currentTheme());
  }

  setTheme(themeId: string): void {
    const theme = APP_THEMES.find((t) => t.id === themeId);
    if (!theme) return;
    this._currentThemeId.set(themeId);
    localStorage.setItem(STORAGE_KEY, themeId);
    this.applyTheme(theme);
  }

  private applyTheme(theme: AppTheme): void {
    const root = document.documentElement;
    root.style.setProperty('--page-accent', theme.accent);
    root.style.setProperty('--page-accent-dark', theme.accentDark);
    root.style.setProperty('--page-accent-light', theme.accentLight);
    root.style.setProperty('--page-accent-soft', theme.accentSoft);
    root.style.setProperty('--page-accent-hover', theme.accentHover);
    root.style.setProperty('--page-accent-shadow', theme.accentShadow);
    root.style.setProperty('--page-row-hover', theme.rowHover);
    root.style.setProperty('--page-banner', theme.banner);
    root.style.setProperty('--mat-sys-primary', theme.accent);
  }
}
