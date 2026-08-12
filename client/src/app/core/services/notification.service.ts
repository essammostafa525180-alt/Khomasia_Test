import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({ providedIn: 'root' })
export class NotificationService {
  constructor(private snackBar: MatSnackBar) {}

  success(message: string): void {
    this.open(message, 'notify--success', 3000);
  }

  error(message: string): void {
    this.open(message, 'notify--error', 6000);
  }

  private open(message: string, panelClass: string, duration: number): void {
    this.snackBar.open(message, 'Dismiss', {
      duration,
      panelClass,
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
    });
  }
}
