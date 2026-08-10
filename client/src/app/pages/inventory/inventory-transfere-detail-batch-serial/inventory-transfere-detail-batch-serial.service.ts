import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfereDetailBatchSerial, InventoryTransfereDetailBatchSerial } from '../../../Shared/Model/-inventory-transfere-detail-batch-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryTransfereDetailBatchSerialService extends BaseService<CreateInventoryTransfereDetailBatchSerial, InventoryTransfereDetailBatchSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfereDetailBatchSerial);
  }
}
