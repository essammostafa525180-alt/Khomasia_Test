import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { TranslatePipe } from '@ngx-translate/core';
import { LinkPanelData } from './link-panel.model';

@Component({
  selector: 'app-link-panel',
  standalone: true,
  imports: [CommonModule, RouterLink, TranslatePipe],
  templateUrl: './link-panel.component.html',
  styleUrl: './link-panel.component.css'
})
export class LinkPanelComponent {
  @Input() title = '';
  @Input() icon = '';
  @Input() links: LinkPanelData['links'] = [];
}
