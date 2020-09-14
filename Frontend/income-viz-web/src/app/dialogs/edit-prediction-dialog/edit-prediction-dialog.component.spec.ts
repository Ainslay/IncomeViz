import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPredictionDialogComponent } from './edit-prediction-dialog.component';

describe('EditPredictionDialogComponent', () => {
  let component: EditPredictionDialogComponent;
  let fixture: ComponentFixture<EditPredictionDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPredictionDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPredictionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
