import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateViewRequestStatus, ViewRequestStatus } from '../../../Shared/Model/-view-request-status.model';

@Injectable({ providedIn: 'root' })
export class ViewRequestStatusService extends BaseService<CreateViewRequestStatus, ViewRequestStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ViewRequestStatus);
  }
}
