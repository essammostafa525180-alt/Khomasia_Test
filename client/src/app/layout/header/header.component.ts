import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '@ngx-translate/core';
import { LanguageService } from '../../services/language.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, TranslatePipe],
  templateUrl: './header.component.html',
  host: { style: 'display: contents' }
})
export class HeaderComponent {
  constructor(public langService: LanguageService) {}

  userName = 'أحمد مصطفى';
  userTitle = 'مدير المخزون';
  memberSince = 'يناير 2024';

  theme: 'light' | 'dark' | 'auto' = 'light';

  messages = [
    { name: 'محمد علي', text: 'اتصل بيا لما تفضى...', time: 'منذ 4 ساعات', starred: true, avatar: 'محمد+علي' },
    { name: 'سارة أحمد', text: 'استلمت رسالتك', time: 'منذ 4 ساعات', starred: false, avatar: 'سارة+أحمد' },
    { name: 'نورا سيد', text: 'الموضوع هنا', time: 'منذ 4 ساعات', starred: true, avatar: 'نورا+سيد' },
  ];

  notifications = [
    { icon: 'bi-envelope', text: '4 رسائل جديدة', time: '3 دقائق' },
    { icon: 'bi-people', text: '8 طلبات صداقة', time: '12 ساعة' },
    { icon: 'bi-file-earmark-text', text: '3 تقارير جديدة', time: 'يومين' },
  ];

  setTheme(mode: 'light' | 'dark' | 'auto'): void {
    this.theme = mode;
    const applied = mode === 'auto'
      ? (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light')
      : mode;
    document.documentElement.setAttribute('data-bs-theme', applied);
  }

  toggleFullscreen(): void {
    if (!document.fullscreenElement) {
      document.documentElement.requestFullscreen();
    } else {
      document.exitFullscreen();
    }
  }
}