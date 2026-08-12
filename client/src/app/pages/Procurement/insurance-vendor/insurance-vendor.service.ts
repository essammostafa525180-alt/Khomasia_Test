import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateInsuranceVendor, InsuranceVendor } from '../../../Shared/Model/-insurance-vendor.model';

@Injectable({ providedIn: 'root' })
export class InsuranceVendorService extends BaseService<CreateInsuranceVendor, InsuranceVendor> {
  constructor(http: HttpClient) {
    super(http, Configurations.InsuranceVendor);
  }
}
