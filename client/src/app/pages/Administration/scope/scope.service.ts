import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateScope, Scope } from '../../../Shared/Model/-scope.model';

@Injectable({ providedIn: 'root' })
export class ScopeService extends BaseService<CreateScope, Scope> {
  constructor(http: HttpClient) {
    super(http, Configurations.Scope);
  }
}
