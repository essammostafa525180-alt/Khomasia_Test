import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRoleModelAttribute, SecRoleModelAttribute } from '../../../Shared/Model/-sec-role-model-attribute.model';

@Injectable({ providedIn: 'root' })
export class SecRoleModelAttributeService extends BaseService<CreateSecRoleModelAttribute, SecRoleModelAttribute> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRoleModelAttribute);
  }
}
