import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssignVendorSpecialization, AssignVendorSpecialization } from '../../../Shared/Model/-assign-vendor-specialization.model';

@Injectable({ providedIn: 'root' })
export class AssignVendorSpecializationService extends BaseService<CreateAssignVendorSpecialization, AssignVendorSpecialization> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssignVendorSpecialization);
  }
}
