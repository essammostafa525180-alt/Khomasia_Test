import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderReceive, VendorOrderReceive } from '../../../Shared/Model/-vendor-order-receive.model';

@Injectable({ providedIn: 'root' })
export class GrnService extends BaseService<CreateVendorOrderReceive, VendorOrderReceive> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderReceive);
  }
}
