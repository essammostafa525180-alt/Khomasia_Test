import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTermsAndCondition, TermsAndCondition } from '../../../Shared/Model/-terms-and-condition.model';

@Injectable({ providedIn: 'root' })
export class TermsAndConditionService extends BaseService<CreateTermsAndCondition, TermsAndCondition> {
  constructor(http: HttpClient) {
    super(http, Configurations.TermsAndCondition);
  }
}
