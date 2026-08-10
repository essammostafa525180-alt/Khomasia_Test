import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateUser, User } from '../../../Shared/Model/-user.model';

@Injectable({ providedIn: 'root' })
export class UserService extends BaseService<CreateUser, User> {
  constructor(http: HttpClient) {
    super(http, Configurations.User);
  }
}
