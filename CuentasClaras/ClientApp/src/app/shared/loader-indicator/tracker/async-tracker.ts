import { Subscription } from 'rxjs/Subscription';
import { Subject } from 'rxjs/Subject';
import { AsyncTrackerOptions } from './async-tracker-options';

const isActive: symbol = Symbol('isActive');
const tracking: symbol = Symbol('tracking');
const options: symbol = Symbol('options');
const activationDelayTimeout: symbol = Symbol('activationDelayTimeout');
const minDurationTimeout: symbol = Symbol('minDurationTimeout');

export type PromiseOrSubscription = Promise<any> | Subscription;

export class AsyncTracker {

  /**
   * An observable that emits true or false as the value for `active` changes
   */
  public active$: Subject<boolean> = new Subject();

  /**
   * @param trackerOptions.activationDelay - number of milliseconds that
   * an added promise needs to be pending before this tracker is active.
   * @param trackerOptions.minDuration - Minimum number of milliseconds
   * that a tracker will stay active.
   */
  constructor(trackerOptions: AsyncTrackerOptions = {}) {
    this[tracking] = [];
    this[options] = trackerOptions;
    this.updateIsActive(this);
  }

  /**
   * Returns whether this tracker is currently active.
   * That is, whether any of the promises added to/created by this tracker
   * are still pending. Note: if the `activationDelay` has not elapsed yet, this will return false.
   */
  get active(): boolean {
    return this[isActive];
  }

  /**
   * The count of promises or subscriptions currently being tracked.
   */
  get trackingCount(): number {
    return this[tracking].length;
  }

  /**
   * Returns whether this tracker is currently tracking a request.
   * That is, whether any of the promises / subscriptions added to/created by this tracker are still pending.
   * This method has no regard for `activationDelay`.
   */
  get tracking(): boolean {
    return this[tracking].length > 0;
  }

  /**
   * Add any arbitrary promise or observable subscription to the tracker.
   * `tracker.active` will be true until a promise is resolved or rejected or a subscription emits the first value.
   */
  public add(promiseOrSubscription: PromiseOrSubscription | PromiseOrSubscription[]): void {

    const startMinDuration: () => void = () => {
      if (this[options].minDuration && !this[minDurationTimeout] && this[tracking].length > 0) {
        this[minDurationTimeout] = this.timeoutPromise(this[options].minDuration);
        this[minDurationTimeout].promise.then(() => {
          delete this[minDurationTimeout];
          this.updateIsActive(this);
        });
      }
    };

    if (Array.isArray(promiseOrSubscription)) {
      promiseOrSubscription.forEach((arrayItem) => this.add(arrayItem));
    } else {
      this[tracking].push(promiseOrSubscription);
      if (this[tracking].length === 1) {
        if (this[options].activationDelay) {
          this[activationDelayTimeout] = this.timeoutPromise(this[options].activationDelay);
          this[activationDelayTimeout].promise.then(() => {
            delete this[activationDelayTimeout];
            startMinDuration();
            this.updateIsActive(this);
          });
        } else {
          startMinDuration();
        }
      }
      this.updateIsActive(this);
      if (this.isPromise(promiseOrSubscription)) {
        const promise: Promise<any> = promiseOrSubscription as Promise<any>;
        promise.then(() => {
          this.removeFromTracking(this, promiseOrSubscription);
        }, () => {
          this.removeFromTracking(this, promiseOrSubscription);
        });
      } else if (this.isSubscription(promiseOrSubscription)) {
        const subscription: Subscription = promiseOrSubscription as Subscription;
        subscription.add(() => {
          this.removeFromTracking(this, promiseOrSubscription);
        });
      } else {
        console.log('AsyncTracker.add - Expects either a promise or an observable subscription.');
      }
    }
  }

  /**
   * Causes a tracker to immediately become inactive and stop tracking all current promises and subscriptions.
   */
  public clear(): void {
    if (this[activationDelayTimeout]) {
      this[activationDelayTimeout].cancel();
      delete this[activationDelayTimeout];
    }
    if (this[minDurationTimeout]) {
      this[minDurationTimeout].cancel();
      delete this[minDurationTimeout];
    }
    this[tracking] = [];
    this.updateIsActive(this);
  }

  private isPromise(value: any): boolean {
    return value && typeof value.then === 'function' && typeof value.catch === 'function';
  }

  private isSubscription(value: any): boolean {
    return value instanceof Subscription;
  }

  private removeFromTracking(tracker: AsyncTracker, promiseOrSubscription: PromiseOrSubscription): void {
    if (tracker[minDurationTimeout]) {
      tracker[minDurationTimeout].promise.then(() => {
        this.removeFromTracking(tracker, promiseOrSubscription);
      });
    } else {
      tracker[tracking] = tracker[tracking].filter((item) => item !== promiseOrSubscription);
      if (tracker[tracking].length === 0 && tracker[activationDelayTimeout]) {
        tracker[activationDelayTimeout].cancel();
        delete tracker[activationDelayTimeout];
      }
      this.updateIsActive(tracker);
    }
  }

  private updateIsActive(tracker: AsyncTracker): void {
    if (!tracker[activationDelayTimeout] && (!tracker[minDurationTimeout] || !tracker[isActive])) {
      const oldValue: boolean = tracker[isActive];
      tracker[isActive] = tracker[tracking].length > 0;
      if (oldValue !== tracker[isActive]) {
        tracker.active$.next(tracker[isActive]);
      }
    }
  }

  private timeoutPromise(duration: number): { promise: Promise<any>, cancel: () => void } {
    let cancel: () => void;
    const promise: Promise<any> = new Promise((resolve) => {
      const timerId: any = setTimeout(() => resolve(), duration);
      cancel = () => {
        clearTimeout(timerId);
        resolve();
      };
    });
    return {cancel, promise};
  }

}
