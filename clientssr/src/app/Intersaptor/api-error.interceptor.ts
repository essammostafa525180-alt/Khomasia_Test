// import { HttpErrorResponse, HttpInterceptorFn, HttpResponse } from '@angular/common/http';
// import { inject } from '@angular/core';
// import { Router } from '@angular/router';
// import { catchError, tap, throwError } from 'rxjs';

// /**
//  * Interceptor to catch global API failures and HTTP errors.
//  * Redirects to /not-found for business logic failure (isSuccess: false) 
//  * or common HTTP errors (404, 500, etc).
//  */
// export const apiErrorInterceptor: HttpInterceptorFn = (req, next) => {
//     const router = inject(Router);

//     return next(req).pipe(
//         tap(event => {
//             if (event instanceof HttpResponse) {
//                 const body = event.body as any;
//                 // Business logic failure: response is 200 OK but body says isSuccess: false
//                 if (body && body.isSuccess === false) {
//                     router.navigate(['/not-found'], { replaceUrl: true });
//                 }
//             }
//         }),
//         catchError((error: HttpErrorResponse) => {
//             // Avoid infinite redirect if the error is from the not-found itself? No, routes are components.
//             // Only redirect for important failures, ignore audio fetch usually.
//             if (!req.url.includes('/get-audio/')   ) {
//                 router.navigate(['/not-found'], { replaceUrl: true });
//             }
//             return throwError(() => error);
//         })
//     );
// };
