import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturnDetail, InventoryItemReturnDetail } from '../../../Shared/Model/-inventory-item-return-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnDetailService extends BaseService<CreateInventoryItemReturnDetail, InventoryItemReturnDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturnDetail);
  }
}
