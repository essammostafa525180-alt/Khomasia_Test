import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'hadithFormatter',
  standalone: true
})
export class HadithFormatterPipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer) { }

  transform(value: string): SafeHtml {
    if (!value) return '';

    // الرواة R
    let html = value.replace(/\{R:(\d+):(.+?)\}/g, (match, id, text) => {
      if (id !== '00') {
        return `<a class="rawi-profile" data-id="${id}">${text}</a>`;
      } else {
        return `<span class="rawi-profile-none" style="color:gray;">${text}</span>`;
      }
    });

    // الكلمات T مع title ونص - Tooltip إسلامي أنيق
    html = html.replace(/\{T:(.+?),(.+?)\}/g, (match, title, text) => {
      return `<span dir="rtl" tabindex="0" style="color:red;" class="custom-tooltip-trigger" data-tooltip="${title.trim()}">${text.trim()}</span>`;
    });

    return this.sanitizer.bypassSecurityTrustHtml(html);
  }
}
