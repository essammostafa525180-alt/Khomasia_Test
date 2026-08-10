import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRole, SecRole } from '../../../Shared/Model/-sec-role.model';

@Injectable({ providedIn: 'root' })
export class SecRoleService extends BaseService<CreateSecRole, SecRole> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRole);
  }
}
