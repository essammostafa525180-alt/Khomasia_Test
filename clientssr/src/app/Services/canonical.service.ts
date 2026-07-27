import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CanonicalService {
  constructor(@Inject(DOCUMENT) private doc: Document) {}

  setCanonical(url: string) {
    let link = this.doc.querySelector("link[rel='canonical']") as HTMLLinkElement;

    if (!link) {
      link = this.doc.createElement('link');
      link.setAttribute('rel', 'canonical');
      this.doc.head.appendChild(link);
    }

    link.setAttribute('href', url);
  }
}
