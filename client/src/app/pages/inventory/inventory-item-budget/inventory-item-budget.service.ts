import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemBudget, InventoryItemBudget } from '../../../Shared/Model/-inventory-item-budget.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemBudgetService extends BaseService<CreateInventoryItemBudget, InventoryItemBudget> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemBudget);
  }
}
