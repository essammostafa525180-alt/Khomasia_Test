import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorOrderVendorSelection, VendorOrderVendorSelection } from '../../../Shared/Model/-vendor-order-vendor-selection.model';

@Injectable({ providedIn: 'root' })
export class VendorOrderVendorSelectionService extends BaseService<CreateVendorOrderVendorSelection, VendorOrderVendorSelection> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorOrderVendorSelection);
  }
}
