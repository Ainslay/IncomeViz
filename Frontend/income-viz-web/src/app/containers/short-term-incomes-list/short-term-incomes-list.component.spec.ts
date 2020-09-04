import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortTermIncomesListComponent } from './short-term-incomes-list.component';

describe('ShortTermIncomesListComponent', () => {
  let component: ShortTermIncomesListComponent;
  let fixture: ComponentFixture<ShortTermIncomesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShortTermIncomesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortTermIncomesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
