import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTransferStatus, TransferStatus } from '../../../Shared/Model/-transfer-status.model';

@Injectable({ providedIn: 'root' })
export class TransferStatusService extends BaseService<CreateTransferStatus, TransferStatus> {
  constructor(http: HttpClient) {
    super(http, Configurations.TransferStatus);
  }
}
