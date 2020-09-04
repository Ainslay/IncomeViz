import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LongTermIncomesListItemComponent } from './long-term-incomes-list-item.component';

describe('LongTermIncomesListItemComponent', () => {
  let component: LongTermIncomesListItemComponent;
  let fixture: ComponentFixture<LongTermIncomesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LongTermIncomesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LongTermIncomesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
