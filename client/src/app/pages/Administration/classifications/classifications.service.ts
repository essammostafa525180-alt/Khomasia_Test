import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateClassifications, Classifications } from '../../../Shared/Model/-classifications.model';

@Injectable({ providedIn: 'root' })
export class ClassificationsService extends BaseService<CreateClassifications, Classifications> {
  constructor(http: HttpClient) {
    super(http, Configurations.Classifications);
  }
}
