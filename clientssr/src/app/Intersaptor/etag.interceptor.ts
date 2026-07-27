import { HttpErrorResponse, HttpInterceptorFn, HttpResponse } from '@angular/common/http';
import { catchError, finalize, from, of, shareReplay, switchMap, tap, throwError } from 'rxjs';
import { openDB, DBSchema, IDBPDatabase } from 'idb';



interface ApiCacheDB {
  cache: {
    key: string;
    value: {
      etag: string;
      data: string;
    };
  };
}



const isBrowser =
  typeof window !== 'undefined' &&
  typeof indexedDB !== 'undefined';



let dbPromise: Promise<IDBPDatabase<ApiCacheDB>> | null = null;



if (isBrowser) {
  dbPromise = openDB<ApiCacheDB>('api-cache-db', 1, {
    upgrade(db) {
      db.createObjectStore('cache');
    }
  });
}



const pendingRequests = new Map<string, any>();



function encrypt(data: any): string {
  const json = JSON.stringify(data);
  const reversed = json.split('').reverse().join('');
  const uint8 = new TextEncoder().encode(reversed);
  let binString = '';
  for (let i = 0; i < uint8.length; i++) {
    binString += String.fromCharCode(uint8[i]);
  }
  return btoa(binString);
}


function decrypt(data: string): any {
  const binString = atob(data);
  const uint8 = new Uint8Array(binString.length);
  for (let i = 0; i < binString.length; i++) {
    uint8[i] = binString.charCodeAt(i);
  }
  const reversed = new TextDecoder().decode(uint8);
  const json = reversed.split('').reverse().join('');
  return JSON.parse(json);
}



export const eTagInterceptor: HttpInterceptorFn = (req, next) => {

  if (!isBrowser || req.method !== 'GET' || !dbPromise) {
    return next(req);
  }

  const url = req.urlWithParams;

  // لو فيه request شغال بالفعل
  if (pendingRequests.has(url)) {
    return pendingRequests.get(url);
  }

  const request$ = from(dbPromise).pipe(

    switchMap(db =>
      from(db.get('cache', url)).pipe(

        switchMap(cache => {

          const clonedReq = cache?.etag
            ? req.clone({ setHeaders: { 'If-None-Match': cache.etag } })
            : req;

          return next(clonedReq).pipe(

            tap(async event => {

              if (event instanceof HttpResponse) {

                const newEtag = event.headers.get('ETag');

                if (newEtag) {

                  const encrypted = encrypt(event.body);

                  await db.put('cache', {
                    etag: newEtag,
                    data: encrypted
                  }, url);

                }

              }

            }),

            catchError((err: HttpErrorResponse) => {

              if (err.status === 304 && cache?.data) {

                const decrypted = decrypt(cache.data);

                return of(new HttpResponse({
                  body: decrypted,
                  status: 200,
                  statusText: 'OK',
                  headers: err.headers,
                  url: err.url || undefined
                }));

              }

              return throwError(() => err);

            })

          );

        })

      )

    ),

    shareReplay(1),

    finalize(() => {
      pendingRequests.delete(url);
    })

  );

  pendingRequests.set(url, request$);

  return request$;

};