import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRoleSecurableValue, SecRoleSecurableValue } from '../../../Shared/Model/-sec-role-securable-value.model';

@Injectable({ providedIn: 'root' })
export class SecRoleSecurableValueService extends BaseService<CreateSecRoleSecurableValue, SecRoleSecurableValue> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRoleSecurableValue);
  }
}
