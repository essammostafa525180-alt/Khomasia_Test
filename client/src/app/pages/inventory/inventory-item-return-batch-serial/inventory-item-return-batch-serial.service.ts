import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturnBatchSerial, InventoryItemReturnBatchSerial } from '../../../Shared/Model/-inventory-item-return-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnBatchSerialService extends BaseService<CreateInventoryItemReturnBatchSerial, InventoryItemReturnBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturnBatchSerial);
  }
}
