import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryStockCountPlan, InventoryStockCountPlan } from '../../../Shared/Model/-inventory-stock-count-plan.model';

@Injectable({ providedIn: 'root' })
export class InventoryStockCountPlanService extends BaseService<CreateInventoryStockCountPlan, InventoryStockCountPlan> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryStockCountPlan);
  }
}
