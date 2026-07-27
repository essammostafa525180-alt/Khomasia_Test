// resolvers/book-sharh.resolver.ts
import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';

export const bookSharhResolver: ResolveFn<any> = (route) => {
  const classificationId = Number(route.paramMap.get('classificationId'));
  return inject(HadithService).getAllBookSharh(classificationId);
};