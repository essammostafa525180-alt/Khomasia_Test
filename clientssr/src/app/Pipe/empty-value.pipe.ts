import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'emptyValue',
  standalone: true
})
export class EmptyValuePipe implements PipeTransform {

   constructor(private sanitizer: DomSanitizer) {}

  transform(value: any, fallback: string = 'غير مسجلة'): SafeHtml {
    if (value === null || value === undefined || value === '') {
      return this.sanitizer.bypassSecurityTrustHtml(
        `<span class="empty-value">${fallback}</span>`
      );
    }
    return value;
  }

}

