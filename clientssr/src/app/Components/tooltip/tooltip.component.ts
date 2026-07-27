import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
    selector: 'app-tooltip',
    standalone: true,
    imports: [CommonModule],
    template: `
    <div class="tooltip-container" [@tooltipAnimation]>
      {{ text }}
    </div>
  `,
    styles: [`
    .tooltip-container {
      background: #000;
      color: #fff;
      padding: 10px 18px;
      border-radius: 12px 2px 12px 2px;
      border: 1.5px solid var(--color-accent-main, #c9a227);
      font-family: 'Amiri', serif;
      font-size: 17px;
      font-weight: 700;
      line-height: 1.8;
      direction: rtl;
      text-align: center;
      max-width: 280px;
      width: max-content;
      box-shadow: 0 10px 25px rgba(0, 0, 0, 0.3);
      word-wrap: break-word;
      pointer-events: none;
    }
  `],
    animations: [
        trigger('tooltipAnimation', [
            transition(':enter', [
                style({ opacity: 0, transform: 'translateY(10px)' }),
                animate('200ms cubic-bezier(0.2, 0, 0, 1)', style({ opacity: 1, transform: 'translateY(0)' }))
            ]),
            transition(':leave', [
                animate('150ms cubic-bezier(0.2, 0, 0, 1)', style({ opacity: 0, transform: 'translateY(10px)' }))
            ])
        ])
    ]
})
export class TooltipComponent {
    @Input() text: string = '';
}
