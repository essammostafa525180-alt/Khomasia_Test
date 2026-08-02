import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopItem } from './top-items.model';

@Component({
  selector: 'app-top-items',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './top-items.component.html',
  host: { style: 'display: contents' }
})
export class TopItemsComponent {
  @Input() title: string = 'الأصناف الأكثر استهلاكًا';
  @Input() items: TopItem[] = [];

  get maxQuantity(): number {
    return Math.max(...this.items.map(i => i.quantity), 1);
  }
}