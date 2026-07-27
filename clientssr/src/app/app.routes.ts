import { Routes } from '@angular/router';

import { hadithResolver } from './Resolvers/hadith.resolver';
import { classificationResolver } from './Resolvers/classification.resolver';
import { bookDetailsResolver } from './Resolvers/book-details.resolver';
import { hadithCollectionResolver } from './Resolvers/hadith-collection.resolver';
import { bookSharhResolver } from './Resolvers/book-sharh-resolver';
import { partitionCollectionsResolver } from './Resolvers/partition-collections.resolver';
import { otherSharhResolver } from './Resolvers/other-sharh-resolver';
import { sharhBookDetailsResolver } from './Resolvers/sharh-book-details-resolver';
import { takhreejResolver } from './Resolvers/takhreej-resolver';
import { narratorsResolver } from './Resolvers/narrators.resolver';
import { sharhResolver } from './Resolvers/sharh-resolver';

export const routes: Routes = [

  // Home
  {
    path: '',
    loadComponent: () =>
      import('./Pages/home-page/home-page.component')
        .then(m => m.HomePageComponent)
  },

  // Library
  {
    path: 'library',
    loadComponent: () =>
      import('./Pages/library-page/library-page.component')
        .then(m => m.LibraryPageComponent)
  },

  // About Us
  {
    path: 'aboutUs',
    loadComponent: () =>
      import('./Pages/about-us-page/about-us-page.component')
        .then(m => m.AboutUsPageComponent)
  },

  // Narrators
  {
    path: 'narrators',
    loadComponent: () =>
      import('./Pages/narrators-page/narrators-page.component')
        .then(m => m.NarratorsPageComponent),
    resolve: { narratorsData: narratorsResolver },
    runGuardsAndResolvers: 'paramsOrQueryParamsChange'
  },

  // Partition Collections
  {
    path: 'partition/:partitionId/collections',
    loadComponent: () =>
      import('./Pages/classifications-page/classifications-page.component')
        .then(m => m.ClassificationsPageComponent),
    resolve: { collectionsData: partitionCollectionsResolver }
  },

  // Partition Collection Details
  {
    path: 'partition/:partitionId/collection/:collectionId',
    loadComponent: () =>
      import('./Pages/classifications-page/classifications-page.component')
        .then(m => m.ClassificationsPageComponent),
    resolve: { collectionData: hadithCollectionResolver }
  },

  // Classification Details
  {
    path: 'classification/:id',
    loadComponent: () =>
      import('./Pages/book-details-page/book-details-page.component')
        .then(m => m.BookDetailsPageComponent),
    resolve: { classificationData: classificationResolver },
runGuardsAndResolvers: 'paramsOrQueryParamsChange'
  },

  // Book Babs
  {
    path: 'book/:id/babs',
    loadComponent: () =>
      import('./Pages/bab-details-page/bab-details-page.component')
        .then(m => m.BabDetailsPageComponent),
    resolve: { bookData: bookDetailsResolver },
        runGuardsAndResolvers: 'paramsOrQueryParamsChange'

  },

  // Hadith Page
  {
    path: 'bab/:id/hadith',
    loadComponent: () =>
      import('./Pages/hadith-page/hadith-page.component')
        .then(m => m.HadithPageComponent),
    resolve: { hadithData: hadithResolver },
    runGuardsAndResolvers: 'paramsOrQueryParamsChange'

  },

  // Takhreej
  {
    path: 'takhreej/:id',
    loadComponent: () =>
      import('./Pages/takhreej-page/takhreej-page.component')
        .then(m => m.TakhreejPageComponent),
    resolve: { takhreejData: takhreejResolver }
  },

  // Sharh Book
  {
    path: 'sharh/:classificationId',
    loadComponent: () =>
      import('./Pages/book-sharh-page/book-sharh-page.component')
        .then(m => m.BookPageComponent),
    resolve: { bookSharhData: bookSharhResolver }
  },

  // Other Sharh
  {
    path: 'other-sharh/:id',
    loadComponent: () =>
      import('./Pages/other-sharh-page/other-sharh-page.component')
        .then(m => m.OtherSharhPageComponent),
    resolve: { otherSharhData: otherSharhResolver }
  },

  // Sharh Book Details
  {
    path: 'BookSharh/:id',
    loadComponent: () =>
      import('./Pages/sharh-book-details-page/sharh-book-details-page.component')
        .then(m => m.SharhBookDetailsPageComponent),
    resolve: {  sharhData: sharhResolver  },
        runGuardsAndResolvers: 'paramsOrQueryParamsChange'

  },
  {
    path: '**',
    redirectTo: '',
  },
  {
    path: 'favicon.ico',
    redirectTo: ''
  } 

];