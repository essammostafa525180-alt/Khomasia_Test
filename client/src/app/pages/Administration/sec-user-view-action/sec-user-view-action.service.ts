import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecUserViewAction, SecUserViewAction } from '../../../Shared/Model/-sec-user-view-action.model';

@Injectable({ providedIn: 'root' })
export class SecUserViewActionService extends BaseService<CreateSecUserViewAction, SecUserViewAction> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecUserViewAction);
  }
}
