import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateLanguage, Language } from '../../../Shared/Model/-language.model';

@Injectable({ providedIn: 'root' })
export class LanguageService extends BaseService<CreateLanguage, Language> {
  constructor(http: HttpClient) {
    super(http, Configurations.Language);
  }
}
