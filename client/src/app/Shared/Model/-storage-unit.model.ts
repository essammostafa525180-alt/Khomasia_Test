export interface StorageUnit {
  id: number;
  warehouseFk: number;
  type: number;
  code?: string;
  name?: string;
  description?: string;
  capacity?: number;
  capacityUnit?: string;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateStorageUnit {
  warehouseFk: number;
  type: number;
  code?: string;
  name?: string;
  description?: string;
  capacity?: number;
  capacityUnit?: string;
  isActive: boolean;
}
