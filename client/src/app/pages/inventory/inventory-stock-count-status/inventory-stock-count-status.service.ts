import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountStatus, InventoryStockCountStatus } from '../../../Shared/Model/-inventory-stock-count-status.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountStatusService extends BaseService<CreateInventoryStockCountStatus, InventoryStockCountStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountStatus);
  }
}
