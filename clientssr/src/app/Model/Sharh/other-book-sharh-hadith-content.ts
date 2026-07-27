import { HadithSharhBookContant } from "./hadith-sharh-contant";

export interface OtherBookSharhHadithResponse  {
      bookId: number;
  bookName?: string | null;
  contant: HadithSharhBookContant[];
}
