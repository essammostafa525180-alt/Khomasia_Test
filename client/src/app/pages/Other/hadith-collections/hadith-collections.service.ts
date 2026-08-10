import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateHadithCollections, HadithCollections } from '../../../Shared/Model/-hadith-collections.model';

@Injectable({ providedIn: 'root' })
export class HadithCollectionsService extends BaseService<CreateHadithCollections, HadithCollections> {
  constructor(http: HttpClient) {
    super(http, Configurations.HadithCollections);
  }
}
