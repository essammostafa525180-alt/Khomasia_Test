import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemTransactionType, InventoryItemTransactionType } from '../../../Shared/Model/-inventory-item-transaction-type.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemTransactionTypeService extends BaseService<CreateInventoryItemTransactionType, InventoryItemTransactionType> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemTransactionType);
  }
}
