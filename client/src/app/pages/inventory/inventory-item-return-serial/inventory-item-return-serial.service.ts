import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturnSerial, InventoryItemReturnSerial } from '../../../Shared/Model/-inventory-item-return-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnSerialService extends BaseService<CreateInventoryItemReturnSerial, InventoryItemReturnSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturnSerial);
  }
}
