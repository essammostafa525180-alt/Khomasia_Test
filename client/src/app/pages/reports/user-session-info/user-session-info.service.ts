import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateUserSessionInfo, UserSessionInfo } from '../../../Shared/Model/-user-session-info.model';

@Injectable({ providedIn: 'root' })
export class UserSessionInfoService extends BaseService<CreateUserSessionInfo, UserSessionInfo> {
  constructor(http: HttpClient) {
    super(http, Configurations.UserSessionInfo);
  }
}
