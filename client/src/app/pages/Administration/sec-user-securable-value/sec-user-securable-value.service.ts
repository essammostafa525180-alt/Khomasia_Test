import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecUserSecurableValue, SecUserSecurableValue } from '../../../Shared/Model/-sec-user-securable-value.model';

@Injectable({ providedIn: 'root' })
export class SecUserSecurableValueService extends BaseService<CreateSecUserSecurableValue, SecUserSecurableValue> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecUserSecurableValue);
  }
}
