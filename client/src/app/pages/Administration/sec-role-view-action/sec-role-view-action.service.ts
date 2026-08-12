import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecRoleViewAction, SecRoleViewAction } from '../../../Shared/Model/-sec-role-view-action.model';

@Injectable({ providedIn: 'root' })
export class SecRoleViewActionService extends BaseService<CreateSecRoleViewAction, SecRoleViewAction> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecRoleViewAction);
  }
}
