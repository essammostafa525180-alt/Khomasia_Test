import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateBabs, Babs } from '../../../Shared/Model/-babs.model';

@Injectable({ providedIn: 'root' })
export class BabsService extends BaseService<CreateBabs, Babs> {
  constructor(http: HttpClient) {
    super(http, Configurations.Babs);
  }
}
