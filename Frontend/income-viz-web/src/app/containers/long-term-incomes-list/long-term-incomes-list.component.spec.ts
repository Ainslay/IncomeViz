import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LongTermIncomesListComponent } from './long-term-incomes-list.component';

describe('LongTermIncomesListComponent', () => {
  let component: LongTermIncomesListComponent;
  let fixture: ComponentFixture<LongTermIncomesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LongTermIncomesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LongTermIncomesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
