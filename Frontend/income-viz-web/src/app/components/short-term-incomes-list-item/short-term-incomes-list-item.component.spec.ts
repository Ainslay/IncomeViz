import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortTermIncomesListItemComponent } from './short-term-incomes-list-item.component';

describe('ShortTermIncomesListItemComponent', () => {
  let component: ShortTermIncomesListItemComponent;
  let fixture: ComponentFixture<ShortTermIncomesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShortTermIncomesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortTermIncomesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
