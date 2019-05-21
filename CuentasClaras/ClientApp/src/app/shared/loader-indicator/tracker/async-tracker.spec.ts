import { async } from '@angular/core/testing';
import { AsyncTracker } from './async-tracker';
import { AsyncTrackerOptions } from './async-tracker-options';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';

describe('AsyncTracker', () => {
  let tracker: AsyncTracker;
  let trackerOptions: AsyncTrackerOptions = {
    activationDelay: 10,
    minDuration: 300
  };

  function subscription() {
    return of({test: 1}).pipe(
      delay( 3000 )
    );
  }

  function promise() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve();
      }, 20);
    });
  }

  beforeEach(() => {
    tracker = new AsyncTracker(trackerOptions);
  });
  it('should add subscription', async(() => {
    expect(tracker).toBeDefined();
    tracker.add(subscription().subscribe());
    setTimeout(() => {
      expect(tracker.tracking).toBeTruthy();
      expect(tracker.active).toBeTruthy();
    }, 15);
  }));
  it('should add array of promises and subscriptions', async(() => {
    expect(tracker).toBeDefined();
    tracker.add([promise(), subscription().subscribe()]);
    expect(tracker.tracking).toBeTruthy();
    setTimeout(() => {
      expect(tracker.active).toBeTruthy();
      expect(tracker.trackingCount).toEqual(2);
    }, 25);
  }));
  it('should clear subscriptions and promises', async(() => {
    expect(tracker).toBeDefined();
    tracker.add([promise(), subscription().subscribe()]);
    expect(tracker.trackingCount).toEqual(2);
    tracker.clear();
    setTimeout(() => {
      expect(tracker.tracking).toBeFalsy();
      expect(tracker.active).toBeFalsy();
    }, 25);
  }));

});
