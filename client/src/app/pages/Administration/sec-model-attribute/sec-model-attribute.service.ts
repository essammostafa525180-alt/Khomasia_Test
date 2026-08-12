import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSecModelAttribute, SecModelAttribute } from '../../../Shared/Model/-sec-model-attribute.model';

@Injectable({ providedIn: 'root' })
export class SecModelAttributeService extends BaseService<CreateSecModelAttribute, SecModelAttribute> {
  constructor(http: HttpClient) {
    super(http, Configurations.SecModelAttribute);
  }
}
