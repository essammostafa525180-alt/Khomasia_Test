import { ApplicationConfig } from '@angular/core';
import { provideRouter, withRouterConfig, withInMemoryScrolling, withPreloading, PreloadAllModules } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { getArabicPaginatorIntl } from './Shared/arabic-paginator-intl';
import { eTagInterceptor } from './Intersaptor/etag.interceptor';
import { loadingInterceptor } from './Intersaptor/loading.interceptor';
// import { apiErrorInterceptor } from './Intersaptor/api-error.interceptor';
import { provideToastr } from 'ngx-toastr';
import { withEnabledBlockingInitialNavigation } from '@angular/router';
import { HighContrastModeDetector } from '@angular/cdk/a11y';
import { SpeedHighContrastModeDetector } from './Services/high-contrast-override.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes,
      withEnabledBlockingInitialNavigation(),
      withRouterConfig({ onSameUrlNavigation: 'reload' }),
      withInMemoryScrolling({ scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled' }),
      withPreloading(PreloadAllModules)
    ),
    provideClientHydration(),
    provideHttpClient(withFetch(), withInterceptors([eTagInterceptor, loadingInterceptor])),
    provideAnimationsAsync(),
    // provideAnimations(),
    provideToastr({
      timeOut: 2000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true,
      tapToDismiss: true
    }),
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: {
        hasBackdrop: true,
        direction: 'rtl'
      }
    },
    { provide: MatPaginatorIntl, useValue: getArabicPaginatorIntl() },
    { provide: HighContrastModeDetector, useClass: SpeedHighContrastModeDetector }
  ]
};
