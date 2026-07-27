import { Injectable, NgZone, PLATFORM_ID, inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LoadingService {
  private activeRequests = 0;
  private readonly _loading$ = new BehaviorSubject<boolean>(false);
  readonly loading$ = this._loading$.asObservable();

  private readonly isBrowser = isPlatformBrowser(inject(PLATFORM_ID));

  constructor(private ngZone: NgZone) {}

  start() {
    if (!this.isBrowser) return;
    this.activeRequests++;
    if (this.activeRequests === 1) {
      this._loading$.next(true);
    }
  }

  stop() {
    if (!this.isBrowser) return;
    if (this.activeRequests > 0) {
      this.activeRequests--;
      if (this.activeRequests === 0) {
        this._loading$.next(false); 
      }
    }
  }
}