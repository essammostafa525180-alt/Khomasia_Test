import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateLine, Line } from '../../../Shared/Model/-line.model';

@Injectable({ providedIn: 'root' })
export class LineService extends BaseService<CreateLine, Line> {
  constructor(http: HttpClient) {
    super(http, Configurations.Line);
  }
}
