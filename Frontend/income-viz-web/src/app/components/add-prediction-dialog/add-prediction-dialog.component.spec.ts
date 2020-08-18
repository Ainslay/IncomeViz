import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPredictionDialogComponent } from './add-prediction-dialog.component';

describe('AddPredictionDialogComponent', () => {
  let component: AddPredictionDialogComponent;
  let fixture: ComponentFixture<AddPredictionDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPredictionDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPredictionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
