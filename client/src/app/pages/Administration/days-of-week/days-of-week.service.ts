import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateDaysOfWeek, DaysOfWeek } from '../../../Shared/Model/-days-of-week.model';

@Injectable({ providedIn: 'root' })
export class DaysOfWeekService extends BaseService<CreateDaysOfWeek, DaysOfWeek> {
  constructor(http: HttpClient) {
    super(http, Configurations.DaysOfWeek);
  }
}
