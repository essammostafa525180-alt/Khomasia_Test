import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendor, Vendor } from '../../../Shared/Model/-vendor.model';

@Injectable({ providedIn: 'root' })
export class VendorService extends BaseService<CreateVendor, Vendor> {
  constructor(http: HttpClient) {
    super(http, Configurations.Vendor);
  }
}
