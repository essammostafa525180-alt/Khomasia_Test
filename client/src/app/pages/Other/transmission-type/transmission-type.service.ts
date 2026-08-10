import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTransmissionType, TransmissionType } from '../../../Shared/Model/-transmission-type.model';

@Injectable({ providedIn: 'root' })
export class TransmissionTypeService extends BaseService<CreateTransmissionType, TransmissionType> {
  constructor(http: HttpClient) {
    super(http, Configurations.TransmissionType);
  }
}
