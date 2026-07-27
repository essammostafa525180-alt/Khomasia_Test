import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'highlightText',
  standalone: true
})
export class HighlightTextPipe implements PipeTransform {

   constructor(private sanitizer: DomSanitizer) {}



  transform(value: string): SafeHtml {
    if (!value) return '';

    // نقسم النص لقطع: تاجات HTML <...> وقطع نص عادي بينها
    // عشان نضمن إن التلوين يشتغل فقط على النص الظاهر،
    // ومش يلمس attributes أي tag موجود مسبقًا (زي <font color=#F87939 size=5px>)
    const parts = value.split(/(<[^>]+>)/g);

    const processText = (text: string): string => {
      let result = text;

      // 1️⃣ الأقواس () → أزرق + الكلام أخضر
      result = result.replace(/\((.*?)\)/g, (match, p1) => {
        return `<span class="bracket"> ( </span><span style="color: green;">${p1}</span><span class="bracket"> ) </span>`;
      });

      // 2️⃣ الأقواس {} → موف + الكلام أزرق فاتح
      result = result.replace(/\{(.*?)\}/g, (match, p1) => {
        return `<span class="bracket"> { </span><span style="color: green;">${p1}</span><span class="bracket"> } </span>`;
      });

      // 3️⃣ الأقواس [] → أخضر مخضر + الكلام أبيض غامق
      result = result.replace(/\[(.*?)\]/g, (match, p1) => {
        return `<span class="bracket"> [ </span><span style="color: green;">${p1}</span><span class="bracket"> ] </span>`;
      });

      // 4️⃣ الأرقام → أحمر
      result = result.replace(/\d+/g, (match) => ` <span style="color: red;"> ${match} </span> `);

      return result;
    };

    const output = parts
      .map(part => {
        // لو القطعة دي tag كامل (بتبدأ بـ < وتنتهي بـ >) سيبها زي ما هي
        if (/^<[^>]+>$/.test(part)) {
          return part;
        }
        // غير كده دي قطعة نص عادي، طبّق عليها التلوين
        return processText(part);
      })
      .join('');

    return this.sanitizer.bypassSecurityTrustHtml(output);
  }
}