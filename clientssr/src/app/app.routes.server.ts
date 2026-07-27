import { RenderMode, ServerRoute } from '@angular/ssr';

export const serverRoutes: ServerRoute[] = [
  // Static routes
  { path: '', renderMode: RenderMode.Server },
  { path: 'library', renderMode: RenderMode.Server },
  { path: 'aboutUs', renderMode: RenderMode.Server },
  { path: 'narrators', renderMode: RenderMode.Server },

  // Dynamic routes — لازم تتحدد صريح
  { path: 'book/:id/babs', renderMode: RenderMode.Server },
  { path: 'bab/:id/hadith', renderMode: RenderMode.Server },
  { path: 'classification/:id', renderMode: RenderMode.Server },
  { path: 'takhreej/:id', renderMode: RenderMode.Server },
  { path: 'sharh/:classificationId', renderMode: RenderMode.Server },
  { path: 'other-sharh/:id', renderMode: RenderMode.Server },
  { path: 'BookSharh/:id', renderMode: RenderMode.Server },
  { path: 'partition/:partitionId/collections', renderMode: RenderMode.Server },
  { path: 'partition/:partitionId/collection/:collectionId', renderMode: RenderMode.Server },

  // Fallback
  { path: '**', renderMode: RenderMode.Server }
];
