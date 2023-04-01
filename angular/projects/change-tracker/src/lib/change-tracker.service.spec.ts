import { TestBed } from '@angular/core/testing';
import { ChangeTrackerService } from './services/change-tracker.service';
import { RestService } from '@abp/ng.core';

describe('ChangeTrackerService', () => {
  let service: ChangeTrackerService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(ChangeTrackerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
