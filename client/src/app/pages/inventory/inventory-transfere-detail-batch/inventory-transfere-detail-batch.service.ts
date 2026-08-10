import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfereDetailBatch, InventoryTransfereDetailBatch } from '../../../Shared/Model/-inventory-transfere-detail-batch.model';

@Injectable({ providedIn: 'root' })
export class InventoryTransfereDetailBatchService extends BaseService<CreateInventoryTransfereDetailBatch, InventoryTransfereDetailBatch> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfereDetailBatch);
  }
}
