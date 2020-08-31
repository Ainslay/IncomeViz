import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PredictionTopBarComponent } from './prediction-top-bar.component';

describe('PredictionTopBarComponent', () => {
  let component: PredictionTopBarComponent;
  let fixture: ComponentFixture<PredictionTopBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PredictionTopBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PredictionTopBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
