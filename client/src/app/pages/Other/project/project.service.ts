import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateProject, Project } from '../../../Shared/Model/-project.model';

@Injectable({ providedIn: 'root' })
export class ProjectService extends BaseService<CreateProject, Project> {
  constructor(http: HttpClient) {
    super(http, Configurations.Project);
  }
}
