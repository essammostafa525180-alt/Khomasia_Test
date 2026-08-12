import { Injectable, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

export type AppLanguage = 'ar' | 'en';

@Injectable({ providedIn: 'root' })
export class LanguageService {
  private translate = inject(TranslateService);
  private storageKey = 'app_language';

  currentLang: AppLanguage = 'ar';

  init(): void {
    const saved = (localStorage.getItem(this.storageKey) as AppLanguage) || 'ar';
    this.setLanguage(saved);
  }

  setLanguage(lang: AppLanguage): void {
    this.currentLang = lang;
    this.translate.use(lang);
    localStorage.setItem(this.storageKey, lang);

    const dir = lang === 'ar' ? 'rtl' : 'ltr';
    document.documentElement.setAttribute('lang', lang);
    document.documentElement.setAttribute('dir', dir);

    this.swapStylesheet('bootstrap-css', dir === 'rtl'
      ? '/vendor/bootstrap/bootstrap.rtl.min.css'
      : '/vendor/bootstrap/bootstrap.min.css');

    this.swapStylesheet('adminlte-css', dir === 'rtl'
      ? '/vendor/adminlte/adminlte.rtl.css'
      : '/vendor/adminlte/adminlte.min.css');
  }

  toggle(): void {
    this.setLanguage(this.currentLang === 'ar' ? 'en' : 'ar');
  }

  private swapStylesheet(id: string, href: string): void {
    let link = document.getElementById(id) as HTMLLinkElement | null;
    if (!link) {
      link = document.createElement('link');
      link.id = id;
      link.rel = 'stylesheet';
      document.head.appendChild(link);
    }
    link.href = href;
  }
}