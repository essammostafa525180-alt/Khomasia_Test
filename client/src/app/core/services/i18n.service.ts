import { DOCUMENT } from '@angular/common';
import { Injectable, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

const STORAGE_KEY = 'app_lang';

@Injectable({ providedIn: 'root' })
export class I18nService {
  private readonly translate = inject(TranslateService);
  private readonly document = inject(DOCUMENT);

  readonly supportedLangs = ['en', 'ar'] as const;

  init(): void {
    this.translate.addLangs([...this.supportedLangs]);

    const saved = localStorage.getItem(STORAGE_KEY);
    const lang = this.isSupported(saved) ? saved : 'en';
    this.setLang(lang, false);
  }

  setLang(lang: string, persist = true): void {
    if (!this.isSupported(lang)) return;

    this.translate.use(lang).subscribe();
    this.applyDocumentLanguage(lang);

    if (persist) localStorage.setItem(STORAGE_KEY, lang);
  }

  getCurrentLang(): string {
    return this.translate.getCurrentLang() || this.translate.getFallbackLang() || 'en';
  }

  private isSupported(lang: string | null | undefined): lang is (typeof this.supportedLangs)[number] {
    if (!lang) return false;
    return (this.supportedLangs as readonly string[]).includes(lang);
  }

  private applyDocumentLanguage(lang: string): void {
    const isRtl = lang === 'ar';
    this.document.documentElement.lang = lang;
    this.document.documentElement.dir = isRtl ? 'rtl' : 'ltr';
  }
}
