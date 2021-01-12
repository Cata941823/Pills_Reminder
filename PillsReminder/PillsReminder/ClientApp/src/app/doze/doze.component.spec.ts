import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DozeComponent } from './doze.component';

describe('DozeComponent', () => {
  let component: DozeComponent;
  let fixture: ComponentFixture<DozeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DozeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DozeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
