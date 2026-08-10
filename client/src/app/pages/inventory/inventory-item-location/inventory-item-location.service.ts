import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemLocation, InventoryItemLocation } from '../../../Shared/Model/-inventory-item-location.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemLocationService extends BaseService<CreateInventoryItemLocation, InventoryItemLocation> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemLocation);
  }
}
