import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRequestWithdrawSerial, RequestWithdrawSerial } from '../../../Shared/Model/-request-withdraw-serial.model';

@Injectable({ providedIn: 'root' })
export class RequestWithdrawSerialService extends BaseService<CreateRequestWithdrawSerial, RequestWithdrawSerial> {
  constructor(http: HttpClient) {
    super(http, Configurations.RequestWithdrawSerial);
  }
}
