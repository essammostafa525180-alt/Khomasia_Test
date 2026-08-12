import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssignVendorEvaluationCriterion, AssignVendorEvaluationCriterion } from '../../../Shared/Model/-assign-vendor-evaluation-criterion.model';

@Injectable({ providedIn: 'root' })
export class AssignVendorEvaluationCriterionService extends BaseService<CreateAssignVendorEvaluationCriterion, AssignVendorEvaluationCriterion> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssignVendorEvaluationCriterion);
  }
}
