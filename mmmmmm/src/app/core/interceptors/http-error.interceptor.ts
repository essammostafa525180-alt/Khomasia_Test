import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { NotificationService } from '../services/notification.service';

/** Generic messages by status — server text is never shown, to avoid leaking internals. */
const MESSAGES: Record<number, string> = {
  0: 'Cannot reach the server. Check your connection and try again.',
  400: 'The submitted data is not valid. Please review it and try again.',
  401: 'Your session has expired. Please sign in again.',
  403: 'You are not allowed to perform this action.',
  404: 'The requested record was not found.',
  409: 'This record conflicts with existing data.',
  422: 'The submitted data could not be processed.',
};

/** Shows every failed request to the user, then re-throws so callers can still react. */
export const httpErrorInterceptor: HttpInterceptorFn = (req, next) => {
  const notification = inject(NotificationService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      // Diagnostic context only — no request/response bodies, no headers.
      console.error(`HTTP ${req.method} ${req.urlWithParams} failed with status ${error.status}`);

      notification.error(
        MESSAGES[error.status] ??
          (error.status >= 500
            ? 'A server error occurred. Please try again later.'
            : 'The request could not be completed.')
      );
      return throwError(() => error);
    })
  );
};
