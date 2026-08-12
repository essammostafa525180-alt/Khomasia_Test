import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryTransfereDetail, InventoryTransfereDetail } from '../../../Shared/Model/-inventory-transfere-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryTransfereDetailService extends BaseService<CreateInventoryTransfereDetail, InventoryTransfereDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryTransfereDetail);
  }
}
