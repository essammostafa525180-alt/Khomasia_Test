export interface Isle {
  id: number;
  storageUnitFk: number;
  code?: string;
  name?: string;
  sequence?: number;
  isActive: boolean;
  isDeleted: boolean;
}

export interface CreateIsle {
  storageUnitFk: number;
  code?: string;
  name?: string;
  sequence?: number;
  isActive: boolean;
}
