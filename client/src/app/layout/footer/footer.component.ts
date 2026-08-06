import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [],
  templateUrl: './footer.component.html',
  host: { style: 'display: contents' }
})
export class FooterComponent {
    currentYear = new Date().getFullYear();

}