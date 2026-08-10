import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateHadithSharhMissing, HadithSharhMissing } from '../../../Shared/Model/-hadith-sharh-missing.model';

@Injectable({ providedIn: 'root' })
export class HadithSharhMissingService extends BaseService<CreateHadithSharhMissing, HadithSharhMissing> {
  constructor(http: HttpClient) {
    super(http, Configurations.HadithSharhMissing);
  }
}
