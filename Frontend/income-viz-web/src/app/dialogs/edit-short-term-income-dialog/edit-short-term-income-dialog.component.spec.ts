import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditShortTermIncomeDialogComponent } from './edit-short-term-income-dialog.component';

describe('EditShortTermIncomeDialogComponent', () => {
  let component: EditShortTermIncomeDialogComponent;
  let fixture: ComponentFixture<EditShortTermIncomeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditShortTermIncomeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditShortTermIncomeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
