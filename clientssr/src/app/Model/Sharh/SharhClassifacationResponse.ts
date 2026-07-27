import { BabListResponse } from "../Babs/bab-list-response";

export interface SharhClassifacationResponse {
  id: number;
  name: string;
  books: SharhClassifacationBookResponse[];
}

export interface SharhClassifacationBookResponse {
  id: number;
  name: string;
  babs:BabListResponse[];
}
