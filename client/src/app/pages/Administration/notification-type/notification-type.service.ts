import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationType, NotificationType } from '../../../Shared/Model/-notification-type.model';

@Injectable({ providedIn: 'root' })
export class NotificationTypeService extends BaseService<CreateNotificationType, NotificationType> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationType);
  }
}
