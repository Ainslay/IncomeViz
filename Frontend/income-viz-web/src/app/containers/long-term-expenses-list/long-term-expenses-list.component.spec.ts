import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LongTermExpensesListComponent } from './long-term-expenses-list.component';

describe('LongTermExpensesListComponent', () => {
  let component: LongTermExpensesListComponent;
  let fixture: ComponentFixture<LongTermExpensesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LongTermExpensesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LongTermExpensesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
