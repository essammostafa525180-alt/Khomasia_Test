import { Component, Input, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MenuItem } from '../sidebar/sidebar.model';
import { TranslatePipe } from '@ngx-translate/core';
@Component({
  selector: 'app-sidebar-menu-item',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive, TranslatePipe, forwardRef(() => SidebarMenuItemComponent)],
  templateUrl: './sidebar-menu-item.component.html',
  host: { style: 'display: contents' }
})
export class SidebarMenuItemComponent {
  @Input() item!: MenuItem;
  @Input() siblings: MenuItem[] = [];   // إخوته على نفس المستوى
  @Input() level: number = 0;

  toggle(): void {
    if (!this.item.children?.length) return;

    const willExpand = !this.item.expanded;

    // اقفل كل الإخوة (على نفس المستوى بس)
    this.siblings.forEach(sibling => {
      if (sibling !== this.item) {
        sibling.expanded = false;
      }
    });

    this.item.expanded = willExpand;
  }
}