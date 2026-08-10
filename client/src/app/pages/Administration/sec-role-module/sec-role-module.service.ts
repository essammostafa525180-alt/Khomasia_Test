import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRoleModule, SecRoleModule } from '../../../Shared/Model/-sec-role-module.model';

@Injectable({ providedIn: 'root' })
export class SecRoleModuleService extends BaseService<CreateSecRoleModule, SecRoleModule> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRoleModule);
  }
}
