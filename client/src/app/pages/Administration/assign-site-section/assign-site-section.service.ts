import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateAssignSiteSection, AssignSiteSection } from '../../../Shared/Model/-assign-site-section.model';

@Injectable({ providedIn: 'root' })
export class AssignSiteSectionService extends BaseService<CreateAssignSiteSection, AssignSiteSection> {
  constructor(http: HttpClient) {
    super(http, Configurations.AssignSiteSection);
  }
}
