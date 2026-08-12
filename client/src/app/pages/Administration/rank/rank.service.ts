import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateRank, Rank } from '../../../Shared/Model/-rank.model';

@Injectable({ providedIn: 'root' })
export class RankService extends BaseService<CreateRank, Rank> {
  constructor(http: HttpClient) {
    super(http, Configurations.Rank);
  }
}
