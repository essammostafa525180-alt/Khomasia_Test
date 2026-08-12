import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationTemplateContact, NotificationTemplateContact } from '../../../Shared/Model/-notification-template-contact.model';

@Injectable({ providedIn: 'root' })
export class NotificationTemplateContactService extends BaseService<CreateNotificationTemplateContact, NotificationTemplateContact> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationTemplateContact);
  }
}
