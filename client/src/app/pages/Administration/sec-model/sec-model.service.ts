import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecModel, SecModel } from '../../../Shared/Model/-sec-model.model';

@Injectable({ providedIn: 'root' })
export class SecModelService extends BaseService<CreateSecModel, SecModel> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecModel);
  }
}
