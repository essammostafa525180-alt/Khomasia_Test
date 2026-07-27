import { BookSummary } from "../Book/book-summary";

export interface ClassificationSummary {
  id: number;
  name: string | null;
  aboutBook: string | null;
  books: BookSummary[];
}
export interface ClassificationDetails {
  id: number;
  name: string | null;
  aboutBook: string | null;
}