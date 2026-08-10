import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotification, Notification } from '../../../Shared/Model/-notification.model';

@Injectable({ providedIn: 'root' })
export class NotificationService extends BaseService<CreateNotification, Notification> {
  constructor(http: HttpClient) {
    super(http, Configurations.Notification);
  }
}
