import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import {
  Component,
  forwardRef,
  Input,
  Output,
  EventEmitter,
  signal,
  inject,
  DestroyRef,
} from '@angular/core';
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormControl,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { debounceTime, distinctUntilChanged, finalize, map, Observable, of, startWith, Subject, switchMap, takeUntil } from 'rxjs';

import { MatIcon } from '@angular/material/icon';
import { BaseService } from '../../../core/services/base.service';

@Component({
  selector: 'app-autocomplete',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    MatInputModule,
    MatIcon
  ],
  templateUrl: './autoComplete.component.html',
  styleUrl: './autoComplete.component.css',
   providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AutocompleteComponent),
      multi: true
    }
  ]
})
export class AutocompleteComponent<T> implements ControlValueAccessor {

  // ─── Inputs ───────────────────────────────────────────────────────────────
   @Input() apiSearch?: BaseService<any, any>;
 
  @Input() displayKey: string = 'name';

  @Input() valueKey?: string;


  @Input() bindWith: string | ((item: T | null) => string) = () => '';
 
  @Input() label = 'Select...';
  @Input() placeholder = 'Search...';
  @Input() minLength = 1;
  @Input() debounce = 300;
 
  // ─── Outputs ──────────────────────────────────────────────────────────────
 
  @Output() selected = new EventEmitter<T>();
  @Output() selectionChange = new EventEmitter<T>();
 
  // ─── State ────────────────────────────────────────────────────────────────
 
  control = new FormControl<T | string>('');
  items    = signal<T[]>([]);
  searched = signal(false);   
 
  private destroyRef = inject(DestroyRef);

  private get activeService(): BaseService<any, any> | undefined {
    return this.apiSearch ;
  }
 
  // ─── Lifecycle ────────────────────────────────────────────────────────────
 
  ngOnInit(): void {
    this.control.valueChanges.pipe(
      debounceTime(this.debounce),
      distinctUntilChanged(),
      map((v) => (typeof v === 'string' ? v : this.getItemLabel(v))),
      switchMap((q) => {
        const term = q?.trim() ?? '';
 
        if (!term || term.length < this.minLength || !this.activeService) {
          this.searched.set(false);
          this.items.set([]);
          return of([]);
        }
 
        this.searched.set(false);
 
        return this.activeService.searchLookUp<any>(term).pipe(
          finalize(() => {
            this.searched.set(true);
          }),
        );
      }),
      takeUntilDestroyed(this.destroyRef),
    ).subscribe((results: any) => {
      const list = Array.isArray(results)
        ? results
        : (results?.items || results?.data || results?.result || []);
      this.items.set(list);
    });
  }
 
  // ─── Helpers ──────────────────────────────────────────────────────────────
 
  getItemLabel(item: any): string {
    if (!item) return '';
    if (typeof item === 'string') return item;

    if (typeof this.bindWith === 'function') {
      const res = this.bindWith(item);
      if (res) return res;
    }
    if (typeof this.bindWith === 'string' && this.bindWith && item[this.bindWith] !== undefined) {
      return String(item[this.bindWith]);
    }
    if (this.displayKey && item[this.displayKey] !== undefined) {
      return String(item[this.displayKey]);
    }
    if (item.name !== undefined) return String(item.name);
    if (item.label !== undefined) return String(item.label);

    return String(item);
  }

 
  displayFn = (item: any): string => this.getItemLabel(item);
 
  // ─── Actions ──────────────────────────────────────────────────────────────
 
  onSelected(item: T): void {
    const emittedVal = this.valueKey && item && typeof item === 'object'
      ? (item as any)[this.valueKey]
      : item;

    this.control.setValue(item, { emitEvent: false });
    this.onChange(emittedVal);
    this.onTouched();
    this.selected.emit(emittedVal);
    this.selectionChange.emit(emittedVal);
  }

 
  // ─── ControlValueAccessor ─────────────────────────────────────────────────
 
  writeValue(value: T | null): void {
    this.control.setValue(value, { emitEvent: false });
  }
 
  onChange  = (_: any) => {};
  onTouched = () => {};
 
  registerOnChange(fn: any):  void { this.onChange  = fn; }
  registerOnTouched(fn: any): void { this.onTouched = fn; }
 
  setDisabledState(disabled: boolean): void {
    disabled ? this.control.disable() : this.control.enable();
  }
}