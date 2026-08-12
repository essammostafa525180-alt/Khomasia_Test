import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorReturn, VendorReturn } from '../../../Shared/Model/-vendor-return.model';

@Injectable({ providedIn: 'root' })
export class SupplierReturnService extends BaseService<CreateVendorReturn, VendorReturn> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorReturn);
  }
}
