import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemSerialStatus, InventoryItemSerialStatus } from '../../../Shared/Model/-inventory-item-serial-status.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemSerialStatusService extends BaseService<CreateInventoryItemSerialStatus, InventoryItemSerialStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemSerialStatus);
  }
}
