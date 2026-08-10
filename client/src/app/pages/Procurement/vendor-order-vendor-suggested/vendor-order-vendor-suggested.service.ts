import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderVendorSuggested, VendorOrderVendorSuggested } from '../../../Shared/Model/-vendor-order-vendor-suggested.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderVendorSuggestedService extends BaseService<CreateVendorOrderVendorSuggested, VendorOrderVendorSuggested> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderVendorSuggested);
  }
}
