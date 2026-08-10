import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateBooks, Books } from '../../../Shared/Model/-books.model';

@Injectable({ providedIn: 'root' })
export class BooksService extends BaseService<CreateBooks, Books> {
  constructor(http: HttpClient) {
    super(http, Configurations.Books);
  }
}
