import { BookSharhListResponse } from "./book-sharh-list-response";

export interface ClassificationWithBookSharhListResponse {
  id: number;
  name: string;
  sharhBook:BookSharhListResponse[];
}

