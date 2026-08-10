import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVendorEvaluationCriterion, VendorEvaluationCriterion } from '../../../Shared/Model/-vendor-evaluation-criterion.model';

@Injectable({ providedIn: 'root' })
export class VendorEvaluationCriterionService extends BaseService<CreateVendorEvaluationCriterion, VendorEvaluationCriterion> {
  constructor(http: HttpClient) {
    super(http, Configurations.VendorEvaluationCriterion);
  }
}
