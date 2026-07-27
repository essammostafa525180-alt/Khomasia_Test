import { Injectable, Inject } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class SeoService {
  constructor(
    private titleService: Title,
    private metaService: Meta,
    @Inject(DOCUMENT) private dom: any
  ) {}

  /**
   * تحديث بيانات SEO بالكامل لصفحة معينة
   */
  updateSeoData(title: string, description: string, keywords: string = '', imageUrl: string = 'assets/images/hadith-logo.webp') {
    const fullTitle = `${title} | جامع السنة وشروحها`;
    this.titleService.setTitle(fullTitle);

    // تحديث الميتا الأساسية
    this.metaService.updateTag({ name: 'description', content: description });
    if (keywords) {
      this.metaService.updateTag({ name: 'keywords', content: keywords });
    }

    // OpenGraph (Facebook)
    this.metaService.updateTag({ property: 'og:title', content: fullTitle });
    this.metaService.updateTag({ property: 'og:description', content: description });
    this.metaService.updateTag({ property: 'og:image', content: imageUrl });
    this.metaService.updateTag({ property: 'og:url', content: this.dom.URL });

    // Twitter Card
    this.metaService.updateTag({ name: 'twitter:card', content: 'summary_large_image' });
    this.metaService.updateTag({ name: 'twitter:title', content: fullTitle });
    this.metaService.updateTag({ name: 'twitter:description', content: description });
    this.metaService.updateTag({ name: 'twitter:image', content: imageUrl });

    // تحديث رابط الـ Canonical
    this.updateCanonicalUrl(this.dom.URL);
  }

  /**
   * إضافة أو تحديث رابط Canonical لمنع تكرار المحتوى
   */
  updateCanonicalUrl(url: string) {
    let link: HTMLLinkElement = this.dom.querySelector("link[rel='canonical']");
    if (!link) {
      link = this.dom.createElement('link');
      link.setAttribute('rel', 'canonical');
      this.dom.head.appendChild(link);
    }
    link.setAttribute('href', url);
  }

  /**
   * إضافة بيانات منظمة (Structured Data) لمحركات البحث
   */
  setStructuredData(data: any) {
    let script = this.dom.querySelector('script[type="application/ld+json"]');
    if (!script) {
      script = this.dom.createElement('script');
      script.setAttribute('type', 'application/ld+json');
      this.dom.head.appendChild(script);
    }
    script.text = JSON.stringify(data);
  }
}
