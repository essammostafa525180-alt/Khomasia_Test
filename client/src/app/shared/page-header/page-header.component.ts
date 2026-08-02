import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbItem } from './breadcrumb-item.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './page-header.component.html',
  host: { style: 'display: contents' }
})
export class PageHeaderComponent {
  @Input() title: string = '';
  @Input() breadcrumbs: BreadcrumbItem[] = [];
}