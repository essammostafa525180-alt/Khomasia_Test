import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateUnitOfMeasure, UnitOfMeasure } from '../../../Shared/Model/-unit-of-measure.model';

@Injectable({ providedIn: 'root' })
export class UnitOfMeasureService extends BaseService<CreateUnitOfMeasure, UnitOfMeasure> {
  constructor(http: HttpClient) {
    super(http, Configurations.UnitOfMeasure);
  }
}
