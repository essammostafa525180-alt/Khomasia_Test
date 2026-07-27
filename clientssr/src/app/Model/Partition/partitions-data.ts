import { Partition } from "./partition";

export interface PartitionsData {
  items: Partition[];
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  nextPage: boolean;
}