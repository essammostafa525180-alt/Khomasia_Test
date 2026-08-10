import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePoserviceRecomendedResource, PoserviceRecomendedResource } from '../../../Shared/Model/-poservice-recomended-resource.model';

@Injectable({ providedIn: 'root' })
export class PoserviceRecomendedResourceService extends BaseService<CreatePoserviceRecomendedResource, PoserviceRecomendedResource> {
  constructor(http: HttpClient) {
    super(http, Configurations.PoserviceRecomendedResource);
  }
}
