import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateTakheejs, Takheejs } from '../../../Shared/Model/-takheejs.model';

@Injectable({ providedIn: 'root' })
export class TakheejsService extends BaseService<CreateTakheejs, Takheejs> {
  constructor(http: HttpClient) {
    super(http, Configurations.Takheejs);
  }
}
