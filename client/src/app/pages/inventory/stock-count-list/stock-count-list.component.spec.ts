import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockCountListComponent } from './stock-count-list.component';

describe('StockCountListComponent', () => {
  let component: StockCountListComponent;
  let fixture: ComponentFixture<StockCountListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StockCountListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockCountListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
