import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateCostCenter, CostCenter } from '../../../Shared/Model/-cost-center.model';

@Injectable({ providedIn: 'root' })
export class CostCenterService extends BaseService<CreateCostCenter, CostCenter> {
  constructor(http: HttpClient) {
    super(http, Configurations.CostCenter);
  }
}
