import { Component } from '@angular/core';

/** Application footer, rendered once by the master page. */
@Component({
  selector: 'app-footer',
  standalone: true,
  template: `
    <footer class="app-footer">
      <span>© {{ year }}, Made with AHCC</span>
      <span class="app-footer__links">
        <a href="#">Support</a>
      </span>
    </footer>
  `,
  styles: [
    `
      .app-footer {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 16px 28px;
        font-size: 12.5px;
        color: var(--app-muted);
      }
      .app-footer__links {
        display: flex;
        gap: 16px;
      }
      .app-footer__links a {
        color: var(--page-accent);
        text-decoration: none;
      }
      .app-footer__links a:hover {
        text-decoration: underline;
      }
    `,
  ],
})
export class FooterComponent {
  readonly year = new Date().getFullYear();
}
