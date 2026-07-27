import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'splitTaxt',
  standalone: true
})
export class SplitTaxtPipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return value;

    // تجاهل أي مسافات أو أسطر قبل كلمة "الحافظ"
    const match = value.match(/.*?للحافظ.*/s);
    return match ? match[0].replace(/.*?(للحافظ.*)/s, '$1') : value;
  }
}
