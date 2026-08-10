import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfereSerial, InventoryTransfereSerial } from '../../../Shared/Model/-inventory-transfere-serial.model';

@Injectable({ providedIn: 'root' })
export class InventoryTransfereSerialService extends BaseService<CreateInventoryTransfereSerial, InventoryTransfereSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfereSerial);
  }
}
