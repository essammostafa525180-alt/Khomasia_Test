import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateOil, Oil } from '../../../Shared/Model/-oil.model';

@Injectable({ providedIn: 'root' })
export class OilService extends BaseService<CreateOil, Oil> {
  constructor(http: HttpClient) {
    super(http, Configurations.Oil);
  }
}
