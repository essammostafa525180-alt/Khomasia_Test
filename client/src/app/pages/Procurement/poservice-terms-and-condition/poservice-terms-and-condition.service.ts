import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceTermsAndCondition, PoserviceTermsAndCondition } from '../../../Shared/Model/-poservice-terms-and-condition.model';

@Injectable({ providedIn: 'root' })
export class PoserviceTermsAndConditionService extends BaseService<CreatePoserviceTermsAndCondition, PoserviceTermsAndCondition> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceTermsAndCondition);
  }
}
