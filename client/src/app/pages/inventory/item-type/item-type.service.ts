import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateItemType, ItemType } from '../../../Shared/Model/-item-type.model';

@Injectable({ providedIn: 'root' })
export class ItemTypeService extends BaseService<CreateItemType, ItemType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ItemType);
  }
}
