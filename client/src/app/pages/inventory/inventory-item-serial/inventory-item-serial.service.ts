import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemSerial, InventoryItemSerial } from '../../../Shared/Model/-inventory-item-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemSerialService extends BaseService<CreateInventoryItemSerial, InventoryItemSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemSerial);
  }
}
