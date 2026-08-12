import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePossessionType, PossessionType } from '../../../Shared/Model/-possession-type.model';

@Injectable({ providedIn: 'root' })
export class PossessionTypeService extends BaseService<CreatePossessionType, PossessionType> {
  constructor(http: HttpClient) {
    super(http, Configurations.PossessionType);
  }
}
