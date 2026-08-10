import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemLocationBatchSerial, InventoryItemLocationBatchSerial } from '../../../Shared/Model/-inventory-item-location-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class ItemBalanceService extends BaseService<CreateInventoryItemLocationBatchSerial, InventoryItemLocationBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemLocationBatchSerial);
  }
}
