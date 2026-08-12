import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePruser, Pruser } from '../../../Shared/Model/-pruser.model';

@Injectable({ providedIn: 'root' })
export class PruserService extends BaseService<CreatePruser, Pruser> {
  constructor(http: HttpClient) {
    super(http, Configurations.Pruser);
  }
}
