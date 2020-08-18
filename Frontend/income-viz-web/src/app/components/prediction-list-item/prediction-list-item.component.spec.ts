import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PredictionListItemComponent } from './prediction-list-item.component';

describe('PredictionListItemComponent', () => {
  let component: PredictionListItemComponent;
  let fixture: ComponentFixture<PredictionListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PredictionListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PredictionListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
