import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateWarrantyStatus, WarrantyStatus } from '../../../Shared/Model/-warranty-status.model';

@Injectable({ providedIn: 'root' })
export class WarrantyStatusService extends BaseService<CreateWarrantyStatus, WarrantyStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.WarrantyStatus);
  }
}
