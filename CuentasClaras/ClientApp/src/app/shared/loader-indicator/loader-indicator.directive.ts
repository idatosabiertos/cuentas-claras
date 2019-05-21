import { Directive, DoCheck, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';
import { AsyncTracker } from './tracker/async-tracker';
import { AsyncTrackerFactory } from './tracker/async-tracker-factory';
import { Subscription } from 'rxjs/Subscription';

/**
 * Directive
 * directive to show a loader
 */
@Directive({
  selector: '[appLoaderIndicator]',
  providers: [AsyncTrackerFactory]
})
export class LoaderIndicatorDirective implements OnInit, DoCheck {
  @Input() public loaderType: string;
  @Input() public busy: Subscription;
  private busyRef: Subscription;
  private runClass = 'running';
  private asyncTracker: AsyncTracker;

  constructor(public element: ElementRef,
              public renderer: Renderer2,
              asyncTrackerFactory: AsyncTrackerFactory) {
    this.asyncTracker = asyncTrackerFactory.create();
  }

  public ngOnInit() {
    this.setLoaderType();
    this.asyncTracker.active$.subscribe((value) => {
      if (value) {
        this.run();
      } else {
        this.stop();
      }
    });
  }

  public ngDoCheck() {
    if (this.busy && this.busy !== this.busyRef) {
      this.busyRef = this.busy;
      this.asyncTracker.add(this.busy);
    }
  }

  private setLoaderType() {
    this.renderer.addClass(this.element.nativeElement, this.loaderType);
  }

  private run() {
    this.renderer.addClass(this.element.nativeElement, this.runClass);
    this.enableDisable(true);
  }

  private stop() {
    this.renderer.removeClass(this.element.nativeElement, this.runClass);
    this.enableDisable(false);
  }

  private enableDisable(value) {
    this.element.nativeElement.disabled = value;
  }
}
