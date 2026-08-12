import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

import { LinkPanelLink } from './link-panel.model';

@Component({
  selector: 'app-link-panel',
  standalone: true,

  imports: [
    CommonModule,
    RouterModule
  ],

  templateUrl: './link-panel.component.html',
  styleUrl: './link-panel.component.css'
})
export class LinkPanelComponent {

  @Input({ required: true })
  title!: string;

  @Input()
  icon = '';

  @Input()
  links: LinkPanelLink[] = [];
}