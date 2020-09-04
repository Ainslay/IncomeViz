import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LongTermExpensesListItemComponent } from './long-term-expenses-list-item.component';

describe('LongTermExpensesListItemComponent', () => {
  let component: LongTermExpensesListItemComponent;
  let fixture: ComponentFixture<LongTermExpensesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LongTermExpensesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LongTermExpensesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
