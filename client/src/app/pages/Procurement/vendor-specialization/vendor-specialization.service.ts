import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorSpecialization, VendorSpecialization } from '../../../Shared/Model/-vendor-specialization.model';

@Injectable({ providedIn: 'root' })
export class VendorSpecializationService extends BaseService<CreateVendorSpecialization, VendorSpecialization> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorSpecialization);
  }
}
