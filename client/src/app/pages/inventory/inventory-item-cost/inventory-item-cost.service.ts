import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemCost, InventoryItemCost } from '../../../Shared/Model/-inventory-item-cost.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemCostService extends BaseService<CreateInventoryItemCost, InventoryItemCost> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemCost);
  }
}
