import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTransferReason, TransferReason } from '../../../Shared/Model/-transfer-reason.model';

@Injectable({ providedIn: 'root' })
export class TransferReasonService extends BaseService<CreateTransferReason, TransferReason> {
  constructor(http: HttpClient) {
    super(http, Configurations.TransferReason);
  }
}
