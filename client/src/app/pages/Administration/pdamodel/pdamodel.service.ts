import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePdamodel, Pdamodel } from '../../../Shared/Model/-pdamodel.model';

@Injectable({ providedIn: 'root' })
export class PdamodelService extends BaseService<CreatePdamodel, Pdamodel> {
  constructor(http: HttpClient) {
    super(http, Configurations.Pdamodel);
  }
}
