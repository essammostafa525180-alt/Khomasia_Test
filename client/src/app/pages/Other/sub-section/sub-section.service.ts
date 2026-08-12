import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSubSection, SubSection } from '../../../Shared/Model/-sub-section.model';

@Injectable({ providedIn: 'root' })
export class SubSectionService extends BaseService<CreateSubSection, SubSection> {
  constructor(http: HttpClient) {
    super(http, Configurations.SubSection);
  }
}
