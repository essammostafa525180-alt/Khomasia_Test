import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-stat-box',
  standalone: true,
  imports: [],
  templateUrl: './stat-box.component.html',
  host: { style: 'display: contents' }
})
export class StatBoxComponent {
  @Input() value: string = '';
  @Input() label: string = '';
  @Input() icon: string = 'bi-graph-up';
  @Input() color: 'primary' | 'success' | 'warning' | 'danger' = 'primary';
  @Input() link: string = '#';
}