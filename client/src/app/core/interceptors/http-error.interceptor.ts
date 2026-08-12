// import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
// import { inject } from '@angular/core';
// import { TranslateService } from '@ngx-translate/core';
// import { catchError, throwError } from 'rxjs';
// import { NotificationService } from '../services/notification.service';

// /** Generic message keys by status — server text is never shown, to avoid leaking internals. */
// const MESSAGE_KEYS: Record<number, string> = {
//   0: 'HTTP_ERRORS.NO_CONNECTION',
//   400: 'HTTP_ERRORS.BAD_REQUEST',
//   401: 'HTTP_ERRORS.UNAUTHORIZED',
//   403: 'HTTP_ERRORS.FORBIDDEN',
//   404: 'HTTP_ERRORS.NOT_FOUND',
//   409: 'HTTP_ERRORS.CONFLICT',
//   422: 'HTTP_ERRORS.UNPROCESSABLE',
// };

// /** Shows every failed request to the user, then re-throws so callers can still react. */
// export const httpErrorInterceptor: HttpInterceptorFn = (req, next) => {
//   const notification = inject(NotificationService);
//   const translate = inject(TranslateService);

//   return next(req).pipe(
//     catchError((error: HttpErrorResponse) => {
//       // Diagnostic context only — no request/response bodies, no headers.
//       console.error(`HTTP ${req.method} ${req.urlWithParams} failed with status ${error.status}`);

//       const key =
//         MESSAGE_KEYS[error.status] ??
//         (error.status >= 500 ? 'HTTP_ERRORS.SERVER_ERROR' : 'HTTP_ERRORS.GENERIC');

//       notification.error(translate.instant(key));
//       return throwError(() => error);
//     })
//   );
// };









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
