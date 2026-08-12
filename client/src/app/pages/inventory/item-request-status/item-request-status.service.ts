import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateItemRequestStatus, ItemRequestStatus } from '../../../Shared/Model/-item-request-status.model';

@Injectable({ providedIn: 'root' })
export class ItemRequestStatusService extends BaseService<CreateItemRequestStatus, ItemRequestStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.ItemRequestStatus);
  }
}
