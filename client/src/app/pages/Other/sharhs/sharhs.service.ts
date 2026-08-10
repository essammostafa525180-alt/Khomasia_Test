import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSharhs, Sharhs } from '../../../Shared/Model/-sharhs.model';

@Injectable({ providedIn: 'root' })
export class SharhsService extends BaseService<CreateSharhs, Sharhs> {
  constructor(http: HttpClient) {
    super(http, Configurations.Sharhs);
  }
}
