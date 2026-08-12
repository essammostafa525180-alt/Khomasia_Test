import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationTemplate, NotificationTemplate } from '../../../Shared/Model/-notification-template.model';

@Injectable({ providedIn: 'root' })
export class NotificationTemplateService extends BaseService<CreateNotificationTemplate, NotificationTemplate> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationTemplate);
  }
}
