import { HadithListResponse } from "./hadith-list-response";

export interface HadithContantResponse {
  classificationId: number;
  classificationName?: string | null;
  bookId: number;
  bookName?: string | null;
  babId: number;
  babName?: string | null;
  hadiths: HadithListResponse[];
}