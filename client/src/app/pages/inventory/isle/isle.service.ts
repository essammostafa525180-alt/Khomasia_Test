import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateIsle, Isle } from '../../../Shared/Model/-isle.model';

@Injectable({ providedIn: 'root' })
export class IsleService extends BaseService<CreateIsle, Isle> {
  constructor(http: HttpClient) {
    super(http, Configurations.Isle);
  }
}
