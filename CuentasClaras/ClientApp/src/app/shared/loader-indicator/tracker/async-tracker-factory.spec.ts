import {
  inject,
  TestBed
} from '@angular/core/testing';
import { AsyncTrackerFactory } from './async-tracker-factory';

describe('AsyncTrackerFactory', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [AsyncTrackerFactory],
  }));
  it('should create a new instance of AsyncTracker',
    inject([AsyncTrackerFactory], (trackerFactory: AsyncTrackerFactory) => {
      let asyncTracker = trackerFactory.create();
      expect(asyncTracker).toBeDefined();
    })
  );

});
