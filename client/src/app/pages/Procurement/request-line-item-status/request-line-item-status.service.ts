import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRequestLineItemStatus, RequestLineItemStatus } from '../../../Shared/Model/-request-line-item-status.model';

@Injectable({ providedIn: 'root' })
export class RequestLineItemStatusService extends BaseService<CreateRequestLineItemStatus, RequestLineItemStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.RequestLineItemStatus);
  }
}
