import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRwDeliveredQuantity, RwDeliveredQuantity } from '../../../Shared/Model/-rw-delivered-quantity.model';

@Injectable({ providedIn: 'root' })
export class RwDeliveredQuantityService extends BaseService<CreateRwDeliveredQuantity, RwDeliveredQuantity> {
  constructor(http: HttpClient) {
    super(http, Configurations.RwDeliveredQuantity);
  }
}
