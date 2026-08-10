import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateMaterialCategory, MaterialCategory } from '../../../Shared/Model/-material-category.model';

@Injectable({ providedIn: 'root' })
export class MaterialCategoryService extends BaseService<CreateMaterialCategory, MaterialCategory> {
  constructor(http: HttpClient) {
    super(http, Configurations.MaterialCategory);
  }
}
