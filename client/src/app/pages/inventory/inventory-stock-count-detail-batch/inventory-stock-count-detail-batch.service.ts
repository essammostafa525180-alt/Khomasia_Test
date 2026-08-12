import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountDetailBatch, InventoryStockCountDetailBatch } from '../../../Shared/Model/-inventory-stock-count-detail-batch.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountDetailBatchService extends BaseService<CreateInventoryStockCountDetailBatch, InventoryStockCountDetailBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountDetailBatch);
  }
}
