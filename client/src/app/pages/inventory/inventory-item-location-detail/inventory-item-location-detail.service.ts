import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemLocationDetail, InventoryItemLocationDetail } from '../../../Shared/Model/-inventory-item-location-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemLocationDetailService extends BaseService<CreateInventoryItemLocationDetail, InventoryItemLocationDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemLocationDetail);
  }
}
