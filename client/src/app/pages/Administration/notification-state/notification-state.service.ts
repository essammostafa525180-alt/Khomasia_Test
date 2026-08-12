import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationState, NotificationState } from '../../../Shared/Model/-notification-state.model';

@Injectable({ providedIn: 'root' })
export class NotificationStateService extends BaseService<CreateNotificationState, NotificationState> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationState);
  }
}
