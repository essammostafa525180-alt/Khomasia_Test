import { Injectable } from '@angular/core';
import { HighContrastModeDetector } from '@angular/cdk/a11y';

@Injectable({
  providedIn: 'root'
})
export class SpeedHighContrastModeDetector extends HighContrastModeDetector {
  override _applyBodyHighContrastModeCssClasses(): void {
    // Disable startup styling invalidations by doing nothing.
  }

  override getHighContrastMode(): number {
    return 0; // Return HighContrastMode.NONE (0) to bypass style checks.
  }
}
