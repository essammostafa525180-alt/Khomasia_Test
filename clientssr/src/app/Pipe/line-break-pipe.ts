import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'lineBreak',
})
export class LineBreakPipe implements PipeTransform {

 transform(value: string | null | undefined): string {
    if (!value) {
      return '';
    }
    var temp=  value.replace(/\./g, '.<br>')
    temp=temp.replace(/\:/g, ':<br>');
    temp=temp.replace(/\]/g, ']<br>');
    

    return temp;
  }

}
