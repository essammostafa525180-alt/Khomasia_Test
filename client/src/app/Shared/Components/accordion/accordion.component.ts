import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '@ngx-translate/core';
import { AccordionItem } from '../../Model/AccordionItem';

@Component({
  selector: 'app-accordion',
  imports: [CommonModule, MatIconModule, TranslatePipe],
  templateUrl: './accordion.component.html',
  styleUrl: './accordion.component.css'
})
export class AccordionComponent {
   @Input() item!: AccordionItem;
  @Input() disabled: boolean  = false;
  @Input() variant: 'default' | 'sidebar' = 'default';

  /**
   * Opens the panel when set to true. It only ever opens, never closes, so a
   * manual collapse by the user is not undone on the next change detection.
   */
  @Input() set expanded(open: boolean) {
    if (open) this.isOpen = true;
  }

  isOpen: boolean = false;

  toggle(): void {
    if (this.disabled) return;
    this.isOpen = !this.isOpen;
  }
}
