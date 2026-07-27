import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'wordsLimit',
  standalone: true,
})
export class WordsLimitPipe implements PipeTransform {
  transform(value: string | null | undefined, start: number = 0, limit: number = 3): string {
    if (!value) return '';

    const words = value.trim().split(/\s+/);
    return words.slice(start,  limit).join(' ');
  }
}