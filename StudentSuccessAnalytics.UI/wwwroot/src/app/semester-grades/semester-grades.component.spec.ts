import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SemesterGradesComponent } from './semester-grades.component';

describe('SemesterGradesComponent', () => {
  let component: SemesterGradesComponent;
  let fixture: ComponentFixture<SemesterGradesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SemesterGradesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SemesterGradesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
