import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemStatus, InventoryItemStatus } from '../../../Shared/Model/-inventory-item-status.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemStatusService extends BaseService<CreateInventoryItemStatus, InventoryItemStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemStatus);
  }
}
