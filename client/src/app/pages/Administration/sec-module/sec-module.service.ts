import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecModule, SecModule } from '../../../Shared/Model/-sec-module.model';

@Injectable({ providedIn: 'root' })
export class SecModuleService extends BaseService<CreateSecModule, SecModule> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecModule);
  }
}
