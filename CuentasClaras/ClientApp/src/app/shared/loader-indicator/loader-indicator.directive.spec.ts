import { async, ComponentFixture, TestBed, } from '@angular/core/testing';
import { Component, OnInit } from '@angular/core';
import { By } from '@angular/platform-browser';
/**
 * Load the implementations that should be tested.
 */
import { LoaderIndicatorDirective } from './loader-indicator.directive';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';

describe('loader-indicator', () => {
  /**
   * Create a test component to test directives.
   */
  @Component({
    template: `
      <button loader-indicator [loaderType]="ld-ext-right" [busy]="busy">
        test
        <div class="ld ld-ring ld-spin"></div>
      </button>`
  })
  class TestComponent implements OnInit {
    public result: object;
    private busy: any;

    public ngOnInit() {
      this.busy = this.busyTest().subscribe((data) => {
        this.result = data;
      });
    }

    private busyTest() {
      return of({test: 1}).pipe(delay(100));
    }
  }

  let comp: TestComponent;
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        LoaderIndicatorDirective,
        TestComponent
      ]
    });
  }));
  it('should have class running', async(() => {
    TestBed.compileComponents().then(() => {
      fixture = TestBed.createComponent(TestComponent);
      comp = fixture.componentInstance;
      comp.ngOnInit();
      fixture.detectChanges();
      const directiveEl = fixture.debugElement.query(By.directive(LoaderIndicatorDirective));
      expect(directiveEl).not.toBeNull();
      expect(directiveEl.nativeElement.classList.contains('running')).toBeTruthy();

    });
  }));
  it('should not have class running', async(() => {
    TestBed.compileComponents().then(() => {
      fixture = TestBed.createComponent(TestComponent);
      comp = fixture.componentInstance;
      comp.ngOnInit();
      fixture.detectChanges();
      const directiveEl = fixture.debugElement.query(By.directive(LoaderIndicatorDirective));
      expect(directiveEl).not.toBeNull();
      setTimeout(() => {
        expect(directiveEl.nativeElement.classList.contains('running')).toBeFalsy();
      }, 110);
    });
  }));

});
