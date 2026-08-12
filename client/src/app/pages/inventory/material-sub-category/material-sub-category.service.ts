import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateMaterialSubCategory, MaterialSubCategory } from '../../../Shared/Model/-material-sub-category.model';

@Injectable({ providedIn: 'root' })
export class MaterialSubCategoryService extends BaseService<CreateMaterialSubCategory, MaterialSubCategory> {
  constructor(http: HttpClient) {
    super(http, Configurations.MaterialSubCategory);
  }
}
