import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLongTermIncomeDialogComponent } from './add-long-term-income-dialog.component';

describe('AddLongTermIncomeDialogComponent', () => {
  let component: AddLongTermIncomeDialogComponent;
  let fixture: ComponentFixture<AddLongTermIncomeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLongTermIncomeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLongTermIncomeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
