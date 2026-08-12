import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorStatus, VendorStatus } from '../../../Shared/Model/-vendor-status.model';

@Injectable({ providedIn: 'root' })
export class VendorStatusService extends BaseService<CreateVendorStatus, VendorStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorStatus);
  }
}
