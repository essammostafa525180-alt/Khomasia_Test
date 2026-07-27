import { Component, Input } from '@angular/core';
import { WordsLimitPipe } from '../../Pipe/words-limit.pipe';
import { SplitTaxtPipe } from '../../Pipe/split-taxt.pipe';

@Component({
    selector: 'app-book-sharh-template',
    imports: [WordsLimitPipe, SplitTaxtPipe],
    templateUrl: './book-sharh-template.component.html',
    styleUrl: './book-sharh-template.component.css'
})
export class BookSharhTemplateComponent {
  @Input({ required: true }) bookName: string = '';
  @Input() scale: number = 0.7;
}
