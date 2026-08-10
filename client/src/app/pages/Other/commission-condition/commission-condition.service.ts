import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateCommissionCondition, CommissionCondition } from '../../../Shared/Model/-commission-condition.model';

@Injectable({ providedIn: 'root' })
export class CommissionConditionService extends BaseService<CreateCommissionCondition, CommissionCondition> {
  constructor(http: HttpClient) {
    super(http, Configurations.CommissionCondition);
  }
}
