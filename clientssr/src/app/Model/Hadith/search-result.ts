import { HadithListResponse } from "./hadith-list-response";

export interface SearchResult {
     classificationId: number;
      classificationName: string;
      bookId: number;
      bookName: string ;
      babId: number;
      babName: string ;
      hadith: HadithListResponse;
}
