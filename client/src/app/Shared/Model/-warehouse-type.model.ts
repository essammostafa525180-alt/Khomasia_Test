export interface WarehouseType {
  id: number;
  code?: string;
  name?: string;
  description?: string;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateWarehouseType {
  code?: string;
  name?: string;
  description?: string;
  isActive: boolean;
}
