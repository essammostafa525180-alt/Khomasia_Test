import { HttpInterceptorFn } from '@angular/common/http';
import { inject, PLATFORM_ID } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { LoadingService } from '../Services/loading.service';
import { isPlatformServer } from '@angular/common';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const platformId = inject(PLATFORM_ID);
  const loadingService = inject(LoadingService);

  if (isPlatformServer(platformId)) {
    return next(req);
  }

  loadingService.start();
  return next(req).pipe(
    finalize(() => loadingService.stop())
  );
};