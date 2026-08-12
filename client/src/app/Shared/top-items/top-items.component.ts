import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopItem } from './top-items.model';

@Component({
  selector: 'app-top-items',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './top-items.component.html',
  styleUrl: './top-items.component.css'
})
export class TopItemsComponent {
  @Input() title = '';
  @Input() items: TopItem[] = [];

  percent(item: TopItem): number {
    const max = this.items.reduce((m, i) => Math.max(m, i.quantity), 1);
    return Math.round((item.quantity / max) * 100);
  }
}
