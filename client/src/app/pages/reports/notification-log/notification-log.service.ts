import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationLog, NotificationLog } from '../../../Shared/Model/-notification-log.model';

@Injectable({ providedIn: 'root' })
export class NotificationLogService extends BaseService<CreateNotificationLog, NotificationLog> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationLog);
  }
}
