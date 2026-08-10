import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateModuleSetting, ModuleSetting } from '../../../Shared/Model/-module-setting.model';

@Injectable({ providedIn: 'root' })
export class ModuleSettingService extends BaseService<CreateModuleSetting, ModuleSetting> {
  constructor(http: HttpClient) {
    super(http, Configurations.ModuleSetting);
  }
}
