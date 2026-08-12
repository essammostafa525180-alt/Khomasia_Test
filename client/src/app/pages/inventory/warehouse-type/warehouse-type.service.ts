import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateWarehouseType, WarehouseType } from '../../../Shared/Model/-warehouse-type.model';

@Injectable({ providedIn: 'root' })
export class WarehouseTypeService extends BaseService<CreateWarehouseType, WarehouseType> {
  constructor(http: HttpClient) {
    super(http, Configurations.WarehouseType);
  }
}
