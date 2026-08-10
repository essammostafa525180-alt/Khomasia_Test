import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemUoM, InventoryItemUoM } from '../../../Shared/Model/-inventory-item-uo-m.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemUoMService extends BaseService<CreateInventoryItemUoM, InventoryItemUoM> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemUoM);
  }
}
