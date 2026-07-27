import { BabListResponse } from "../Babs/bab-list-response";

export interface BookDetailsWithBabsResponse {
    classificationId:number
  classificationName: string;
  id:number
  name: string; 
  babs: BabListResponse[];
}
