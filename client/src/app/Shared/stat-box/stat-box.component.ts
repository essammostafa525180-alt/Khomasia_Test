import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-stat-box',
  standalone: true,
  imports: [CommonModule, TranslatePipe],
  templateUrl: './stat-box.component.html',
  styleUrl: './stat-box.component.css'
})
export class StatBoxComponent {
  @Input() value: string | number = 0;
  @Input() label = '';
  @Input() icon = 'bi-box-seam';
  @Input() color: 'primary' | 'success' | 'warning' | 'danger' | 'info' | 'secondary' = 'primary';

  get bgClass(): string {
    return `bg-${this.color}`;
  }
}
