import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRoleProperty, SecRoleProperty } from '../../../Shared/Model/-sec-role-property.model';

@Injectable({ providedIn: 'root' })
export class SecRolePropertyService extends BaseService<CreateSecRoleProperty, SecRoleProperty> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRoleProperty);
  }
}
