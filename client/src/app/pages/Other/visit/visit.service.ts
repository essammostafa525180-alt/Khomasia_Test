import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateVisit, Visit } from '../../../Shared/Model/-visit.model';

@Injectable({ providedIn: 'root' })
export class VisitService extends BaseService<CreateVisit, Visit> {
  constructor(http: HttpClient) {
    super(http, Configurations.Visit);
  }
}
