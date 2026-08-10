import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { CreateExpense, Expense } from '../../../Shared/Model/-expense.model';

@Injectable({ providedIn: 'root' })
export class ExpenseService extends BaseService<CreateExpense, Expense> {
  constructor(http: HttpClient) {
    super(http, Configurations.Expense);
  }
}
