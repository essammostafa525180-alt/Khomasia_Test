import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemEquivalentSp, InventoryItemEquivalentSp } from '../../../Shared/Model/-inventory-item-equivalent-sp.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemEquivalentSpService extends BaseService<CreateInventoryItemEquivalentSp, InventoryItemEquivalentSp> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemEquivalentSp);
  }
}
