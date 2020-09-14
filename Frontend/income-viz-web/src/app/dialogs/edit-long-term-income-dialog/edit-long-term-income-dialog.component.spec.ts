import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLongTermIncomeDialogComponent } from './edit-long-term-income-dialog.component';

describe('EditLongTermIncomeDialogComponent', () => {
  let component: EditLongTermIncomeDialogComponent;
  let fixture: ComponentFixture<EditLongTermIncomeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditLongTermIncomeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditLongTermIncomeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
