import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentSucessComponent } from './student-sucess.component';

describe('StudentSucessComponent', () => {
  let component: StudentSucessComponent;
  let fixture: ComponentFixture<StudentSucessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentSucessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentSucessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
