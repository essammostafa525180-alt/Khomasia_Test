import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecConfiguration, SecConfiguration } from '../../../Shared/Model/-sec-configuration.model';

@Injectable({ providedIn: 'root' })
export class SecConfigurationService extends BaseService<CreateSecConfiguration, SecConfiguration> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecConfiguration);
  }
}
