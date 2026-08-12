import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateWarehouse, Warehouse } from '../../../Shared/Model/-warehouse.model';

@Injectable({ providedIn: 'root' })
export class WarehouseService extends BaseService<CreateWarehouse, Warehouse> {
  constructor(http: HttpClient) {
    super(http, Configurations.Warehouse);
  }
}
