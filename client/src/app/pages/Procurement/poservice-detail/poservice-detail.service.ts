import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceDetail, PoserviceDetail } from '../../../Shared/Model/-poservice-detail.model';

@Injectable({ providedIn: 'root' })
export class PoserviceDetailService extends BaseService<CreatePoserviceDetail, PoserviceDetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceDetail);
  }
}
