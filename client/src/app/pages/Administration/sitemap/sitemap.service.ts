import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateSitemap, Sitemap } from '../../../Shared/Model/-sitemap.model';

@Injectable({ providedIn: 'root' })
export class SitemapService extends BaseService<CreateSitemap, Sitemap> {
  constructor(http: HttpClient) {
    super(http, Configurations.Sitemap);
  }
}
