import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecUserModule, SecUserModule } from '../../../Shared/Model/-sec-user-module.model';

@Injectable({ providedIn: 'root' })
export class SecUserModuleService extends BaseService<CreateSecUserModule, SecUserModule> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecUserModule);
  }
}
