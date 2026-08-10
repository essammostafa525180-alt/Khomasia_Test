import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePdarequestsLog, PdarequestsLog } from '../../../Shared/Model/-pdarequests-log.model';

@Injectable({ providedIn: 'root' })
export class PdarequestsLogService extends BaseService<CreatePdarequestsLog, PdarequestsLog> {
  constructor(http: HttpClient) {
    super(http, Configurations.PdarequestsLog);
  }
}
