import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderType, VendorOrderType } from '../../../Shared/Model/-vendor-order-type.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderTypeService extends BaseService<CreateVendorOrderType, VendorOrderType> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderType);
  }
}
