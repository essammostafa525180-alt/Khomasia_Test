export interface Warehouse {
  id: number;
  warehouseTypeFk: number;
  code?: string;
  name?: string;
  description?: string;
  address?: string;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateWarehouse {
  warehouseTypeFk: number;
  code?: string;
  name?: string;
  description?: string;
  address?: string;
  isActive: boolean;
}
