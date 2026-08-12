import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePdadetail, Pdadetail } from '../../../Shared/Model/-pdadetail.model';

@Injectable({ providedIn: 'root' })
export class PdadetailService extends BaseService<CreatePdadetail, Pdadetail> {
  constructor(http: HttpClient) {
    super(http, Configurations.Pdadetail);
  }
}
