import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderScreen, VendorOrderScreen } from '../../../Shared/Model/-vendor-order-screen.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderScreenService extends BaseService<CreateVendorOrderScreen, VendorOrderScreen> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderScreen);
  }
}
