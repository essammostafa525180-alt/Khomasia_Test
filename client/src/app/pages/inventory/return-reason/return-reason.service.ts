import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateReturnReason, ReturnReason } from '../../../Shared/Model/-return-reason.model';

@Injectable({ providedIn: 'root' })
export class ReturnReasonService extends BaseService<CreateReturnReason, ReturnReason> {
  constructor(http: HttpClient) {
    super(http, Configurations.ReturnReason);
  }
}
