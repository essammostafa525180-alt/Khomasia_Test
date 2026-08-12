import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturnBatch, InventoryItemReturnBatch } from '../../../Shared/Model/-inventory-item-return-batch.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnBatchService extends BaseService<CreateInventoryItemReturnBatch, InventoryItemReturnBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturnBatch);
  }
}
