import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateState, State } from '../../../Shared/Model/-state.model';

@Injectable({ providedIn: 'root' })
export class StateService extends BaseService<CreateState, State> {
  constructor(http: HttpClient) {
    super(http, Configurations.State);
  }
}
