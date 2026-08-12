import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemBudgetDetail, InventoryItemBudgetDetail } from '../../../Shared/Model/-inventory-item-budget-detail.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemBudgetDetailService extends BaseService<CreateInventoryItemBudgetDetail, InventoryItemBudgetDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemBudgetDetail);
  }
}
