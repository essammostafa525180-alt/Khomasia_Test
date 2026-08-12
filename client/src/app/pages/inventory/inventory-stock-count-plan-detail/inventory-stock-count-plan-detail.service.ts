import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountPlanDetail, InventoryStockCountPlanDetail } from '../../../Shared/Model/-inventory-stock-count-plan-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountPlanDetailService extends BaseService<CreateInventoryStockCountPlanDetail, InventoryStockCountPlanDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountPlanDetail);
  }
}
