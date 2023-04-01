import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { ChangeTrackerComponent } from './components/change-tracker.component';
import { ChangeTrackerService } from '@j-s.Abp/change-tracker';
import { of } from 'rxjs';

describe('ChangeTrackerComponent', () => {
  let component: ChangeTrackerComponent;
  let fixture: ComponentFixture<ChangeTrackerComponent>;
  const mockChangeTrackerService = jasmine.createSpyObj('ChangeTrackerService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ChangeTrackerComponent],
      providers: [
        {
          provide: ChangeTrackerService,
          useValue: mockChangeTrackerService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
