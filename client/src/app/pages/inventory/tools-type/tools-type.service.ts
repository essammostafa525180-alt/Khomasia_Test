import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateToolsType, ToolsType } from '../../../Shared/Model/-tools-type.model';

@Injectable({ providedIn: 'root' })
export class ToolsTypeService extends BaseService<CreateToolsType, ToolsType> {
  constructor(http: HttpClient) {
    super(http, Configurations.ToolsType);
  }
}
