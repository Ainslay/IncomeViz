import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortTermExpensesListItemComponent } from './short-term-expenses-list-item.component';

describe('ShortTermExpensesListItemComponent', () => {
  let component: ShortTermExpensesListItemComponent;
  let fixture: ComponentFixture<ShortTermExpensesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShortTermExpensesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortTermExpensesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
