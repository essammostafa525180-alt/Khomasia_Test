import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemReturn, InventoryItemReturn } from '../../../Shared/Model/-inventory-item-return.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemReturnService extends BaseService<CreateInventoryItemReturn, InventoryItemReturn> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemReturn);
  }
}
