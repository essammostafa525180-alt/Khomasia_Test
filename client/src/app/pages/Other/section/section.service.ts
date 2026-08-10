import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSection, Section } from '../../../Shared/Model/-section.model';

@Injectable({ providedIn: 'root' })
export class SectionService extends BaseService<CreateSection, Section> {
  constructor(http: HttpClient) {
    super(http, Configurations.Section);
  }
}
