import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateEngineSize, EngineSize } from '../../../Shared/Model/-engine-size.model';

@Injectable({ providedIn: 'root' })
export class EngineSizeService extends BaseService<CreateEngineSize, EngineSize> {
  constructor(http: HttpClient) {
    super(http, Configurations.EngineSize);
  }
}
