import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderStatus, VendorOrderStatus } from '../../../Shared/Model/-vendor-order-status.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderStatusService extends BaseService<CreateVendorOrderStatus, VendorOrderStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderStatus);
  }
}
