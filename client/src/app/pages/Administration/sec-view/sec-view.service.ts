import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecView, SecView } from '../../../Shared/Model/-sec-view.model';

@Injectable({ providedIn: 'root' })
export class SecViewService extends BaseService<CreateSecView, SecView> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecView);
  }
}
