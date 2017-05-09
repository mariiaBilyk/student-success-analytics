import { TestBed, inject } from '@angular/core/testing';

import { GradesService } from './grades.service';

describe('GradesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GradesService]
    });
  });

  it('should ...', inject([GradesService], (service: GradesService) => {
    expect(service).toBeTruthy();
  }));
});
