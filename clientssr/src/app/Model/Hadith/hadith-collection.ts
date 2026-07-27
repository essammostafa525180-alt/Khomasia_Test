import { Classification } from "../Classification/classification";

export interface HadithCollection {
  id: number;
  name: string | null;
  mainMenuEnabled: boolean;
  classifications: Classification[];
}