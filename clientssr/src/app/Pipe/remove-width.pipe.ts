import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'removeWidth',
  standalone: true
})
export class RemoveWidthPipe implements PipeTransform {

    constructor(private sanitizer: DomSanitizer) {}

  transform(value: string): SafeHtml {
    if (!value) return '';

    // إزالة أي width="..." من table, td, th
    const cleanedHtml = value.replace(/(<(table|td|th)[^>]*?)\s*width="[^"]*"/gi, '$1');

    // رجّع HTML آمن
    return this.sanitizer.bypassSecurityTrustHtml(cleanedHtml);
  }
}


