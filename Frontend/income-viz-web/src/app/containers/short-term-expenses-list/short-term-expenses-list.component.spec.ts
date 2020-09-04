import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortTermExpensesListComponent } from './short-term-expenses-list.component';

describe('ShortTermExpensesListComponent', () => {
  let component: ShortTermExpensesListComponent;
  let fixture: ComponentFixture<ShortTermExpensesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShortTermExpensesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortTermExpensesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
