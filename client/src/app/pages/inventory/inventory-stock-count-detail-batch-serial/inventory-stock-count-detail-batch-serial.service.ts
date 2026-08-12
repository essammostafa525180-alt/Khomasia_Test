import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountDetailBatchSerial, InventoryStockCountDetailBatchSerial } from '../../../Shared/Model/-inventory-stock-count-detail-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountDetailBatchSerialService extends BaseService<CreateInventoryStockCountDetailBatchSerial, InventoryStockCountDetailBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountDetailBatchSerial);
  }
}
