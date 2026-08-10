import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateNotificationPlaceHolder, NotificationPlaceHolder } from '../../../Shared/Model/-notification-place-holder.model';

@Injectable({ providedIn: 'root' })
export class NotificationPlaceHolderService extends BaseService<CreateNotificationPlaceHolder, NotificationPlaceHolder> {
  constructor(http: HttpClient) {
    super(http, Configurations.NotificationPlaceHolder);
  }
}
