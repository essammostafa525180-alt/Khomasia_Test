import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecUserModelAtrribute, SecUserModelAtrribute } from '../../../Shared/Model/-sec-user-model-atrribute.model';

@Injectable({ providedIn: 'root' })
export class SecUserModelAtrributeService extends BaseService<CreateSecUserModelAtrribute, SecUserModelAtrribute> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecUserModelAtrribute);
  }
}
