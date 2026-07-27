import { HadithCollection } from "../Hadith/hadith-collection";

export interface Partition {
  id: number;
  name: string | null;
  hasCollection: boolean;
  hadithCollections: HadithCollection[];
}