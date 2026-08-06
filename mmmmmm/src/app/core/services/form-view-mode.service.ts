import { Injectable, signal } from '@angular/core';
import { FormViewMode } from '../../Shared/Model/FormViewMode';

const STORAGE_KEY = 'app.formViewMode';

/**
 * User preference for how create/edit forms are shown. Persisted per browser;
 * anything other than an exact 'dialog' falls back to the 'page' default, so a
 * hand-edited localStorage value can't put the app in an unknown state.
 */
@Injectable({ providedIn: 'root' })
export class FormViewModeService {
  readonly mode = signal<FormViewMode>(this.readStored());

  isDialog(): boolean {
    return this.mode() === 'dialog';
  }

  set(mode: FormViewMode): void {
    this.mode.set(mode);
    try {
      localStorage.setItem(STORAGE_KEY, mode);
    } catch {
      // Storage unavailable (private mode / disabled) — keep the in-memory value.
    }
  }

  private readStored(): FormViewMode {
    try {
      return localStorage.getItem(STORAGE_KEY) === 'dialog' ? 'dialog' : 'page';
    } catch {
      return 'page';
    }
  }
}
