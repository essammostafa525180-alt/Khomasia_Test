import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecUserProperty, SecUserProperty } from '../../../Shared/Model/-sec-user-property.model';

@Injectable({ providedIn: 'root' })
export class SecUserPropertyService extends BaseService<CreateSecUserProperty, SecUserProperty> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecUserProperty);
  }
}
