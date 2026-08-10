import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateItemQuantityType, ItemQuantityType } from '../../../Shared/Model/-item-quantity-type.model';

@Injectable({ providedIn: 'root' })
export class ItemQuantityTypeService extends BaseService<CreateItemQuantityType, ItemQuantityType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ItemQuantityType);
  }
}
