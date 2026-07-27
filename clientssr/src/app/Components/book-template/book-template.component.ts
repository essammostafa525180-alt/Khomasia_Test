import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-book-template',
    imports: [],
    templateUrl: './book-template.component.html',
    styleUrl: './book-template.component.css'
})
export class BookTemplateComponent {
  @Input({ required: true }) bookName: string | null = '';
   @Input() scale: number = 0.7;
}
