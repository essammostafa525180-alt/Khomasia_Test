import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemTrasnsactionType, InventoryItemTrasnsactionType } from '../../../Shared/Model/-inventory-item-trasnsaction-type.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemTrasnsactionTypeService extends BaseService<CreateInventoryItemTrasnsactionType, InventoryItemTrasnsactionType> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemTrasnsactionType);
  }
}
