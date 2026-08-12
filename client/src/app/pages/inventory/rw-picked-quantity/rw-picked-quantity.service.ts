import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwPickedQuantity, RwPickedQuantity } from '../../../Shared/Model/-rw-picked-quantity.model';

@Injectable({ providedIn: 'root' })
export class RwPickedQuantityService extends BaseService<CreateRwPickedQuantity, RwPickedQuantity> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwPickedQuantity);
  }
}
