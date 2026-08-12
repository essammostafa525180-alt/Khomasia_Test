import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateFactoryLine, FactoryLine } from '../../../Shared/Model/-factory-line.model';

@Injectable({ providedIn: 'root' })
export class FactoryLineService extends BaseService<CreateFactoryLine, FactoryLine> {
  constructor(http: HttpClient) {
    super(http, Configurations.FactoryLine);
  }
}
