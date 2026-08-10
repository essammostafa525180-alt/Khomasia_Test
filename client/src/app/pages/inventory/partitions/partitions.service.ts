import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreatePartitions, Partitions } from '../../../Shared/Model/-partitions.model';

@Injectable({ providedIn: 'root' })
export class PartitionsService extends BaseService<CreatePartitions, Partitions> {
  constructor(http: HttpClient) {
    super(http, Configurations.Partitions);
  }
}
