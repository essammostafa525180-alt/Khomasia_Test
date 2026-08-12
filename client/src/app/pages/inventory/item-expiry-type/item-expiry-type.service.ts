import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateItemExpiryType, ItemExpiryType } from '../../../Shared/Model/-item-expiry-type.model';

@Injectable({ providedIn: 'root' })
export class ItemExpiryTypeService extends BaseService<CreateItemExpiryType, ItemExpiryType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ItemExpiryType);
  }
}
