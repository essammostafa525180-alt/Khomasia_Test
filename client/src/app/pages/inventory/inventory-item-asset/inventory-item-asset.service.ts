import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInventoryItemAsset, InventoryItemAsset } from '../../../Shared/Model/-inventory-item-asset.model';

@Injectable({ providedIn: 'root' })
export class InventoryItemAssetService extends BaseService<CreateInventoryItemAsset, InventoryItemAsset> {
  constructor(http: HttpClient) {
    super(http, Configurations.InventoryItemAsset);
  }
}
