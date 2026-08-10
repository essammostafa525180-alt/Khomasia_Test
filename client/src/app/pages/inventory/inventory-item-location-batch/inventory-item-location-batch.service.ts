import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemLocationBatch, InventoryItemLocationBatch } from '../../../Shared/Model/-inventory-item-location-batch.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemLocationBatchService extends BaseService<CreateInventoryItemLocationBatch, InventoryItemLocationBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemLocationBatch);
  }
}
