import { Injectable, signal } from '@angular/core';
import { FormViewMode } from '../../Shared/Model/FormViewMode';

const STORAGE_KEY = 'app.formViewMode';

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
