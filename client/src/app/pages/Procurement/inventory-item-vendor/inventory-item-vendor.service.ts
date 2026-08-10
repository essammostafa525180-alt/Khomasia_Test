import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemVendor, InventoryItemVendor } from '../../../Shared/Model/-inventory-item-vendor.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemVendorService extends BaseService<CreateInventoryItemVendor, InventoryItemVendor> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemVendor);
  }
}
