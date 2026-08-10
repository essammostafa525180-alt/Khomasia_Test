import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateOwnership, Ownership } from '../../../Shared/Model/-ownership.model';

@Injectable({ providedIn: 'root' })
export class OwnershipService extends BaseService<CreateOwnership, Ownership> {
  constructor(http: HttpClient) {
    super(http, Configurations.Ownership);
  }
}
