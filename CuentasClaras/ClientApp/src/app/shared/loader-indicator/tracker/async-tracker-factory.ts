import { Injectable } from '@angular/core';
import { AsyncTracker } from './async-tracker';
import { AsyncTrackerOptions } from './async-tracker-options';

@Injectable()
export class AsyncTrackerFactory {

  public create(trackerOptions?: AsyncTrackerOptions): AsyncTracker {
    return new AsyncTracker(trackerOptions);
  }

}
