import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAdUser, AdUser } from '../../../Shared/Model/-ad-user.model';

@Injectable({ providedIn: 'root' })
export class AdUserService extends BaseService<CreateAdUser, AdUser> {
  constructor(http: HttpClient) {
    super(http, Configurations.AdUser);
  }
}
