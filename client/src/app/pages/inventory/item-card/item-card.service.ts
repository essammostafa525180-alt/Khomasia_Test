import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItem, InventoryItem } from '../../../Shared/Model/inventory-item.model';

@Injectable({ providedIn: 'root' })
export class ItemCardService extends BaseService<CreateInventoryItem, InventoryItem> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItem);
  }
}
