export interface Shelf {
  id: number;
  isleFk: number;
  code?: string;
  name?: string;
  level?: number;
  maxWeight?: number;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateShelf {
  isleFk: number;
  code?: string;
  name?: string;
  level?: number;
  maxWeight?: number;
  isActive: boolean;
}
