export interface Rack {
  id: number;
  shelfFk: number;
  code?: string;
  name?: string;
  capacity?: number;
  maxWeight?: number;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateRack {
  shelfFk: number;
  code?: string;
  name?: string;
  capacity?: number;
  maxWeight?: number;
  isActive: boolean;
}
