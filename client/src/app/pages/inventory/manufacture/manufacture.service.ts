import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateManufacture, Manufacture } from '../../../Shared/Model/-manufacture.model';

@Injectable({ providedIn: 'root' })
export class ManufactureService extends BaseService<CreateManufacture, Manufacture> {
  constructor(http: HttpClient) {
    super(http, Configurations.Manufacture);
  }
}
