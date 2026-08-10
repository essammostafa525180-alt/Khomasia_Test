import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorType, VendorType } from '../../../Shared/Model/-vendor-type.model';

@Injectable({ providedIn: 'root' })
export class VendorTypeService extends BaseService<CreateVendorType, VendorType> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorType);
  }
}
