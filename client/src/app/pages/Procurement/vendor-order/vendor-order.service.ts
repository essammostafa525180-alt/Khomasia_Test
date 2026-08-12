import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrder, VendorOrder } from '../../../Shared/Model/-vendor-order.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderService extends BaseService<CreateVendorOrder, VendorOrder> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrder);
  }
}
