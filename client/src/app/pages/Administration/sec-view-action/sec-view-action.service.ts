import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecViewAction, SecViewAction } from '../../../Shared/Model/-sec-view-action.model';

@Injectable({ providedIn: 'root' })
export class SecViewActionService extends BaseService<CreateSecViewAction, SecViewAction> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecViewAction);
  }
}
