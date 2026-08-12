import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCount, InventoryStockCount } from '../../../Shared/Model/-inventory-stock-count.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountService extends BaseService<CreateInventoryStockCount, InventoryStockCount> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCount);
  }
}
