import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateHadiths, Hadiths } from '../../../Shared/Model/-hadiths.model';

@Injectable({ providedIn: 'root' })
export class HadithsService extends BaseService<CreateHadiths, Hadiths> {
  constructor(http: HttpClient) {
    super(http, Configurations.Hadiths);
  }
}
