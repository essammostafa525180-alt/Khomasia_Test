import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateUserSessionInfoDetail, UserSessionInfoDetail } from '../../../Shared/Model/-user-session-info-detail.model';

@Injectable({ providedIn: 'root' })
export class UserSessionInfoDetailService extends BaseService<CreateUserSessionInfoDetail, UserSessionInfoDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.UserSessionInfoDetail);
  }
}
