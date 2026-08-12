import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSysKeyValue, SysKeyValue } from '../../../Shared/Model/-sys-key-value.model';

@Injectable({ providedIn: 'root' })
export class SysKeyValueService extends BaseService<CreateSysKeyValue, SysKeyValue> {
  constructor(http: HttpClient) {
    super(http, Configurations.SysKeyValue);
  }
}
