import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountDetail, InventoryStockCountDetail } from '../../../Shared/Model/-inventory-stock-count-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountDetailService extends BaseService<CreateInventoryStockCountDetail, InventoryStockCountDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountDetail);
  }
}
